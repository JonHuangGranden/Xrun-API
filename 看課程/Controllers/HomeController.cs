using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace YourNamespace
{
    [ApiController]
    [Route("[controller]")]
    public class SimpleController : ControllerBase
    {
        private static readonly string[] SampleData = new[]
        {
            "Data1", "Data2", "Data3"
        };

        private readonly ILogger<SimpleController> _logger;

        public SimpleController(ILogger<SimpleController> logger)
        {
            _logger = logger;

        //在这个例子中，SimpleController类有一个构造函数
         // ，它要求在创建SimpleController类的实例时
        // 必须提供一个ILogger<SimpleController> 类型的对象
        // 。这种方式确保了SimpleController实例在被创建时
       // 已经有了一个日志记录器的实例，可以用于日志记录操作。

        }//這算是一個建構函式，建構函式的名字要和類名一樣，並且沒有返回類型
         //例如class BoxFactory
         //{
         //    public BoxFactory()
         //    {
         //        Console.WriteLine("這是一間箱子工廠");
         //    }
         //这段代码是在一个名为SimpleController的类中定义的构造函数。
         ////它接收一个类型为ILogger<SimpleController> 的参数，
         ////并将这个参数赋值给类的一个私有成员变量（假设是_logger）。
         /////这种做法常用于依赖注入，
         ////使得SimpleController类可以在其方法中使用ILogger<SimpleController> 
         /////来记录日志。


        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInformation("处理 GET 请求");
            return SampleData;
        }
    }
}
