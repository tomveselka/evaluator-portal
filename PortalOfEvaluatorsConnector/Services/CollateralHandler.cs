using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PortalOfEvaluatorsCommon.Models;
using PortalOfEvaluatorsCommon.Repo;
using PortalOfEvaluatorsConnector.Models;

namespace PortalOfEvaluatorsConnector.Services;

public class CollateralHandler : ICollateralHandler
{
    private readonly IDatabaseService _databaseService;
    private readonly ILogger<CollateralHandler> _logger;
    private readonly IGenerateGuidService _guidGenerator;
    private readonly Mapper _mapper;

    public CollateralHandler(ILogger<CollateralHandler> logger, IDatabaseService databaseService, IGenerateGuidService guidGenerator)
    {
        _logger = logger;
        _databaseService = databaseService;
        _mapper = AutoMapperConfig.InitializeAutoMapper();
        _guidGenerator = guidGenerator;
    }

    public async Task<IActionResult> AddCollateral(AddCollateralRequest request)
    {
        //TODO: check if request contains all data
        try
        {
            var collateralGuid = _guidGenerator.GenerateGuid();
            var dto = _mapper.Map<AddCollateralRequest, AddCollateralRequestDto>(request);
            await _databaseService.AddCollateral(dto);
        }catch (Exception ex)
        {
            return new OkObjectResult
        (
            new
            {
                message = $"Failed to register Collateral. Exception: {ex}"
            });
        }
        return new OkObjectResult
        (
            new
            {
                message = "OK"
            });
    }
    /*
    public async Task<GetCollateralStatusResponse> GetCollateralStatus(string applicationNumber)
    {
        try
        {
            var dto = await _databaseService.GetCollateralStatus(applicationNumber);
            return _mapper.Map<ApplicationStatusDto, GetCollateralStatusResponse>(dto);
        }
        catch(Exception ex)
        {
            return new GetCollateralStatusResponse()
            {
                Message = ex.Message,
                ExceptionName = ex.GetType().Name
            };
        }
    }*/

    public async Task<IActionResult> GetCollateralStatus(string applicationNumber)
    {
        try
        {
            var dto = await _databaseService.GetCollateralStatus(applicationNumber);
            return new OkObjectResult(_mapper.Map<ApplicationStatusDto, GetCollateralStatusResponse>(dto));
        }
        catch (InvalidOperationException ex)
        {
            var errorResponse = new { Message = "Collateral not found", ItemId = applicationNumber };
            return new NotFoundObjectResult(errorResponse);
        }
        catch (Exception ex)
        {
            var errorResponse = new { Message = ex.Message, ItemId = applicationNumber };
            return new ObjectResult(errorResponse) { StatusCode = 500};
        }
    }

    public Task<IActionResult> DeleteCollateral(DeleteCollateralRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> EditCollateral(EditCollateralRequest request)
    {
        throw new NotImplementedException();
    } 
}
