using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Collections;

namespace BOB.Controllers
{
    /// <summary>
    /// Outcome API
    /// </summary>
    public class OutcomeController : ApiController
    {
        DBDataOperateService dbDataOperateService;

        public OutcomeController()
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
                        "sp_GetOutcomeCategory",
                        null
                    )
                    .Select(x=>
                        new OutcomeCategoryResultViewModels
                        {
                            OutcomeCategoryID = (int)x.ItemArray[0],  
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
