using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using NPOI.SS.Formula.Functions;
using OneOf;
using Org.BouncyCastle.Utilities;
using StorageSystem.Application.Contracts.DataAccess.Base;
using StorageSystem.Application.Contracts.Services;
using StorageSystem.Application.Models;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Bill.Outs;
using StorageSystem.Application.Models.Product.Base;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.Application.Models.Product.Outs;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Features.Services
{
    public class BillService : IBillService
    {
        private readonly ILogger<BillService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BillService(ILogger<BillService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> CreateBill(CreateBillInsDto billDto)
        {
            Bill bill = new Bill();
            bill = _mapper.Map<Bill>(billDto);
            if (billDto.Phone != null)
            {
                _logger.LogInformation($"Check customer exists!");
                Customer customer = await _unitOfWork.CustomerDataAccess.FindCustomerByPhoneNumber(billDto.Phone);
                Customer cus = new Customer();
                if (customer == null)
                {
                    cus.Address = billDto.Address!;
                    cus.Phone = billDto.Phone!;
                    cus.Name = billDto.CustomerName!;

                    await _unitOfWork.CustomerDataAccess.CreateCustomerAsync(cus);
                    bill.CustomerId = cus.Id;
                }
                bill.CustomerId = customer?.Id;
            }
            
            try
            {
                decimal total = billDto.Orders.Sum(item => item.Price * item.Quantity);
                Guid billId = Guid.NewGuid();
                bill.Id = billId;
                bill.Total = total;
                bill.BillDetails = _mapper.Map<List<BillDetail>>(billDto.Orders);
                bill.BillDetails.Select(item =>
                {
                    item.BillId = billId;
                    return item;
                }).ToList();

                await _unitOfWork.BillDataAccess.CreateBillAsync(bill);
                //update quantity product from ids
                //List<UpdateQuantityProductDto> listItems = new List<UpdateQuantityProductDto>();

                //foreach (var item in billDto.Orders)
                //{
                //    UpdateQuantityProductDto updateQuantityProductDto = new UpdateQuantityProductDto();
                //    updateQuantityProductDto.ProductId = item.ProductId;
                //    updateQuantityProductDto.UnitId = item.UnitId;
                //    updateQuantityProductDto.Quantity = item.Quantity;
                //    listItems.Add(updateQuantityProductDto);
                //}

                //var res = await _unitOfWork.ProductDataAccess.UpdateQuantityProductsFromIds(listItems);
                //if (res)
                //{
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                //}
                //return false;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when create bill: {ex.Message}, {ex.InnerException}!");
                return false;
            }
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> DeleteBill(Guid id)
        {
            var bill = await _unitOfWork.BillDataAccess.FindBillById(id);
            if (bill != null)
            {
                try
                {
                    _logger.LogInformation($"Start delete bill");
                    //Bill detail has been deleted
                    _unitOfWork.BillDataAccess.DeleteBill(bill);
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when delete bill: {ex.Message}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists bill!", "400000")
                       }
                   );
        }

        public async Task<OneOf<GetBillForView, LocalizationErrorMessageOutDto, ValidationResult>> FindBillById(Guid id)
        {
            var result = await _unitOfWork.BillDataAccess.FindBillById(id);
            if (result != null)
            {
                return _mapper.Map<GetBillForView>(result);
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists bill!", "400000")
                       }
                   );
        }

        public Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBillDetailsFromBillId()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBillDetailsFromPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<IEnumerable<GetBillForView>, LocalizationErrorMessageOutDto, ValidationResult>> GetAllBills(Paging filter)
        {
            //IEnumerable<Bill> categories = await _unitOfWork.BillDataAccess.GetAllBills(true);
            //IEnumerable<GetBillForView> data = _mapper.Map<IEnumerable<GetBillForView>>(categories);
            //return data.ToList();
            throw new NotImplementedException();
        }

        public async Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> UpdateBill(Guid billId, UpdateBillInsDto billDto)
        {
            Bill bill = await _unitOfWork.BillDataAccess.FindBillById(billId, true);
            if (bill != null)
            {
                _logger.LogInformation($"Start update quantity for product");
                //Loop bill ban đầu
                foreach(var item in bill.BillDetails)
                {
                    //Loop bill hiện tại
                    foreach(var item1 in billDto.Items)
                    {
                        //Nếu sản phẩm cũ:
                        //+ Số lượng ít hơn lúc đầu -> số lượng product + (số lượng lúc đầu - số lượng hiện tại)
                        //+ Số lượng nhiều hơn lúc đầu -> số lượng product - (số lượng hiện tại - số lượng lúc đầu)
                        if(item.ProductId == item1.ProductId)
                        {
                            if(item.Quantity > item1.Quantity)
                            {

                            }else if(item.Quantity < item1.Quantity)
                            {

                            }
                        }
                        //Nếu sản phẩm mới -> trừ số lượng
                        else
                        {

                        }
                    }
                }
                _logger.LogInformation($"Start update bill");
                bill.BillDetails = _mapper.Map<List<BillDetail>>(billDto.Items);
                bill.BillDetails.Select(item =>
                {
                    item.BillId = billId;
                    return item;
                }).ToList();

                try
                {
                    _unitOfWork.BillDataAccess.UpdateBill(bill);
                    //update quantity product from ids
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when update bill: {ex.Message}, {ex.InnerException}!");
                    return false;
                }
                return true;
            }
            return new ValidationResult(
                       new List<ValidationFailure>
                       {
                            new ValidationFailure ("Not exists bill!", "400000")
                       }
                   );
        }

        public Task<OneOf<bool, LocalizationErrorMessageOutDto, ValidationResult>> ReplacementBill(ReplacementBillInsDto model)
        {
            throw new NotImplementedException();
        }
    }
}
