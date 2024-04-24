namespace MongoD

{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    //这个类非常合适，并不多余。它作为一个配置实体，
    //用于将 appsettings.json 中的配置映射到一个强类型的对象上
    //，这使得在代码中使用这些配置更加安全和便捷。


}