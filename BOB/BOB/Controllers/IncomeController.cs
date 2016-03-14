using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Collections;

namespace BOB.Controllers
{
    /// <summary>
    /// Income API
    /// </summary>
    public class IncomeController : ApiController
    {
        DBDataOperateService dbDataOperateService;

        public IncomeController()
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
                        "sp_GetIncomeCategory",
                        null
                    )
                    .Select(x=>
                        new IncomeCategoryResultViewModels
                        {
                            IncomeCategoryID = (int)x.ItemArray[0],  
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

    }
}
