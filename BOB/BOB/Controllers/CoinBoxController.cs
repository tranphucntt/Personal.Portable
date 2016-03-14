using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Collections;

namespace BOB.Controllers
{
    /// <summary>
    /// Coin Box API
    /// </summary>
    public class CoinBoxController : ApiController
    {
        DBDataOperateService dbDataOperateService;

        public CoinBoxController()
        {
            dbDataOperateService = new DBDataOperateService();
            dbDataOperateService.ConnectionString = DBConnectionSetting.BOBConnectionString;
        }

        [HttpPost]
        public IHttpActionResult Category()
        {
            LogHelperService.doLog(
                string.Format(
                    "{0}-{1}",
                    ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString()
                ),
                "Start"
            );         

            var result=
                    dbDataOperateService.GetDataEnumerable(
                        "sp_GetCoinBoxCategory",
                        null
                    )
                    .Select(x=>
                        new CoinBoxCategoryResultViewModels
                        {
                            CoinBoxCategoryID = (int)x.ItemArray[0],  
                            CategoryName =  (string) x.ItemArray[1]                         
                        }
                    ).ToList();

            ActionResultViewModels ActionResultViewModels = new BOB.ActionResultViewModels()
            {
                Code = ActionStatusEnum.Successed,
                Expression = null,
                Result = result
            };

            LogHelperService.doLog(
                 string.Format(
                     "{0}-{1}",
                     ControllerContext.RouteData.Values["controller"].ToString(),
                     ControllerContext.RouteData.Values["action"].ToString()
                 ),
                 "End"
             );

            return Json(ActionResultViewModels);
        }

        [HttpPost]
        public IHttpActionResult Organization()
        {
            LogHelperService.doLog(
                string.Format(
                    "{0}-{1}",
                    ControllerContext.RouteData.Values["controller"].ToString(),
                    ControllerContext.RouteData.Values["action"].ToString()
                ),
                "Start"
            );

            var result =
                    dbDataOperateService.GetDataEnumerable(
                        "sp_GetCoinBoxOrganization",
                        null
                    )
                    .Select(x =>
                        new CoinBoxOrganizationResultViewModels
                        {
                            CoinBoxOrganizationID = (int)x.ItemArray[0],
                            OrganizationName = (string)x.ItemArray[1]
                        }
                    ).ToList();

            ActionResultViewModels ActionResultViewModels = new BOB.ActionResultViewModels()
            {
                Code = ActionStatusEnum.Successed,
                Expression = null,
                Result = result
            };

            LogHelperService.doLog(
                 string.Format(
                     "{0}-{1}",
                     ControllerContext.RouteData.Values["controller"].ToString(),
                     ControllerContext.RouteData.Values["action"].ToString()
                 ),
                 "End"
             );

            return Json(ActionResultViewModels);
        }
    }
}
