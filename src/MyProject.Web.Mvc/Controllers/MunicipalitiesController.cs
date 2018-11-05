using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Abp.Authorization;
using Abp.Web.Models;
using MyProject.Address;
using MyProject.Authorization;
using MyProject.Domains;
using MyProject.Web.Models.DataTables;
using MyProject.Web.Models.Municipalities;
using MyProject.Municipality;


namespace AllPoints.Web.Controllers
{
    [AbpAuthorize(PermissionNames.Page_Municipalities)]
    public class MunicipalitiesController : MyProjectControllerBase
    {
        #region Properties

        private readonly IMunicipalitiesService _municipalitiesService;
        private readonly IAddressServices _addressServices;

        #endregion

        #region Constructor

        public MunicipalitiesController(IMunicipalitiesService municipalitiesService, IAddressServices addressServices)
        {
            _addressServices = addressServices;
            _municipalitiesService = municipalitiesService;


        }

        #endregion

        #region View

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        #endregion

        #region Methods

        
        [HttpGet]
        public async Task<ActionResult> EditMunicipalities(int municipalitiesId)
        {
            if (municipalitiesId == 0)
            {
                return PartialView("_EditMunicipalities", new MunicipalitiesViewModel() {IsActive = true});
            }

            var municipalities = await _municipalitiesService.Get(new EntityDto(municipalitiesId));
            
            
            return PartialView("_EditMunicipalities", new MunicipalitiesViewModel(municipalities));

        }

        #endregion

        #region Post
        [HttpPost]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        public JsonResult MunicipalitiesTable([FromBody] BaseDataTableModel model)
        {
            var data =  _municipalitiesService.GetDataTable(model.Param.SortOrder, model.Param.Search.Value, model.ActiveFilter).ToList();
            var returnData = data.Skip(model.Param.Start).Take(model.Param.Length);

            var result = new
            {
                draw = model.Param.Draw,
                data = returnData.Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Email,
                    x.PointOfContact,
                    x.IsActive
                }),
                recordFiltered = data.Count,
                recordTotal = data.Count
            };
            
            return Json(result);
        }

        
        [HttpPost]
        public async Task<JsonResult> DeleteMunicipalities(int municipalitiesId)
        {
            var municipalityInfo = await _municipalitiesService.Get(new EntityDto(municipalitiesId));
            var idAddressDto = new EntityDto() { Id = municipalityInfo.AddressId };
            await _addressServices.Delete(idAddressDto);

            var idDto = new EntityDto(){Id = municipalitiesId};
            await _municipalitiesService.Delete(idDto);
            return Json(new {reload = true});
        }

        [HttpPost]
        public JsonResult SaveMunicipalities( MunicipalitiesViewModel model)
        {
            var municipalitiesData = model.ConvertToMunicipalities();

            //splitting address and update it separately from municipalities
            if (model.Id != 0)
            {
                Address address = model.ConvertToMunicipalities().Address;
                _addressServices.SaveAddress(address);
            }
           
            _municipalitiesService.SaveMunicipality(municipalitiesData);

            return Json(new {reload = true});
        }
        #endregion

    }

    
}
