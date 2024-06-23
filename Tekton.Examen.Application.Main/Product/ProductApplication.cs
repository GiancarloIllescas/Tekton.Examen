using AutoMapper;
using Tekton.Examen.Application.DTO;
using Tekton.Examen.Domain.Entity;
using Tekton.Examen.Application.Interface;
using Tekton.Examen.Cross.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tekton.Examen.Application.Interface.Features;
using Tekton.Examen.Application.Interface.Persistence;
using Tekton.Examen.Application.Interface.Cache;
using System;
using Tekton.Examen.Application.Interface.Services;
using System.Diagnostics;

namespace Tekton.Examen.Application.Features.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IProductStatusCache _productStatusCache;
        private readonly IProductDiscountService _productDiscountService;
        private readonly IAppLogger<ProductApplication> _logger;

        public ProductApplication(IMapper mapper, IProductRepository productRepository, IAppLogger<ProductApplication> logger, IProductStatusCache productStatusCache, IProductDiscountService productDiscountService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _logger = logger;
            _productStatusCache = productStatusCache;
            _productDiscountService = productDiscountService;
        }


        public Response<ProductDto> GetById(int id)
        {
            var response = new Response<ProductDto>();
            try
            {
                var product = _productRepository.GetById(id);

                if (product == null)
                {
                    response.IsSuccess = true;
                    response.Message = "Id de producto no existe";
                    return response;
                }


                Dictionary<int, string> status = _productStatusCache.GetProductStatusDictionary();
                ProductDiscount productDiscount = _productDiscountService.GetById(product.ProductId);
                product.StatusName = status[product.Status];
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                productDto.Discount = productDiscount.Discount;
                productDto.FinalPrice = productDiscount.Discount == 0 ? productDto.Price : productDto.Price * (1 - (productDiscount.Discount / 100.00));

                response.Data = productDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<ProductDto>> GetByIdAsync(int id)
        {
            var response = new Response<ProductDto>();
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if(product == null)
                {
                    response.IsSuccess = true;
                    response.Message = "Id de producto no existe";
                    return response;
                }


                Dictionary<int, string> status = _productStatusCache.GetProductStatusDictionary();
                ProductDiscount productDiscount = _productDiscountService.GetById(product.ProductId);
                product.StatusName = status[product.Status];
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                productDto.Discount = productDiscount.Discount;
                productDto.FinalPrice = productDiscount.Discount == 0 ? productDto.Price : productDto.Price * (1 - (productDiscount.Discount / 100.00));

                response.Data = productDto;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<bool> Insert(ProductDto productDto)
        {
            var response = new Response<bool>();
            try
            {
                
                var product = _mapper.Map<Tekton.Examen.Domain.Entity.Product>(productDto);
                response.Data = _productRepository.Insert(product);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Resgistro de producto exitoso";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(ProductDto productDto)
        {
            {
                var response = new Response<bool>();
                try
                {
                    var product = _mapper.Map<Tekton.Examen.Domain.Entity.Product>(productDto);
                    response.Data = await _productRepository.InsertAsync(product);
                    if (response.Data)
                    {
                        response.IsSuccess = true;
                        response.Message = "Resgistro de producto exitoso";
                    }
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                }
                return response;
            }
        }

        public Response<bool> Update(ProductDto productDto)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Tekton.Examen.Domain.Entity.Product>(productDto);
                response.Data = _productRepository.Update(product);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion de producto exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ProductDto productDto)
        {
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Tekton.Examen.Domain.Entity.Product>(productDto);
                response.Data = await _productRepository.UpdateAsync(product);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizacion de producto exitosa";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;

        }
    }
}