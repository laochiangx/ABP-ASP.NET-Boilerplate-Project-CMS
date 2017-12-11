ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统

博客园地址：http://www.cnblogs.com/anyushengcms/p/7325126.html


 ![1.png](http://upload-images.jianshu.io/upload_images/6855212-8d191ff98c8946f2.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)


![2.png](http://upload-images.jianshu.io/upload_images/6855212-7a978b6886d1768c.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![3.png](http://upload-images.jianshu.io/upload_images/6855212-db94be8a19ad98d6.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![image.png](http://upload-images.jianshu.io/upload_images/6855212-9bd286dec4b39722.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![image.png](http://upload-images.jianshu.io/upload_images/6855212-3e5b67fa4b0b3364.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)



  看懂远不如动手去做,动手做才能发现很多自己不懂的问题,不断的反思和总结,“乐于分享是一种境界的突破”。" 分享是很有意思，也是可以锻炼人的。 分享意味着自我的不断净化提升，不给自己后退的余地。为什么这么说呢？因为：一，分享的就是你所知道的，你所知道的是你投资时间和精力学来的，分享意味着你做到无私地把它分享出更高的价值，这是很伟大的。二，分享意味着你要不断去追寻新知，这很重要。只有用心生活，用心体会，才能不断有新的东西分享。这就是善于借用外力来完善自己的表现。。三，我们在分享的过程中，学会进一步判断，进一步深入思考，从而进一步提升思绪。这很重要，自己要了解自己，这是一个不断学习的过程。"

   这也是算是一种学习的方法和态度吧,经常去学习和总结,在博客园看了很多大神的文章,写下一点对于ABP(ABP是“ASP.NET Boilerplate Project (ASP.NET样板项目)”的简称)框架的理解和运用.能力有限,第一次写技术性的博客写得不好.算是抛砖引玉,希望有问题的地方给予指出. 

 "ASP.NET Boilerplate是一个用最佳实践和流行技术开发现代WEB应用程序的新起点，它旨在成为一个通用的WEB应用程序框架和项目模板。"

"ASP.NET Boilerplate 基于DDD的经典分层架构思想，实现了众多DDD的概念（但没有实现所有DDD的概念）。"

下面是这期文章的目录：

**1、 [ABP+AdminLTE+Bootstrap Table权限管理系统第一节--使用ASP.NET Boilerplate模板创建解决方案](http://www.jianshu.com/p/9fef959d6c1b)**

**2、[ABP+AdminLTE+Bootstrap Table权限管理系统第二节--数据库脚本](http://www.jianshu.com/p/c7f918a4c513)
[](http://www.cnblogs.com/anyushengcms/p/abp.html)**

**3、[ABP+AdminLTE+Bootstrap Table权限管理系统第三节--abp分层体系及实体相关](http://www.jianshu.com/p/336103fd49d2)**

**4、[ABP+AdminLTE+Bootstrap Table权限管理系统第四节--仓储,服务,服务接口及依赖注入](http://www.jianshu.com/p/514dfc3ae6a2)**

**5、[ABP+AdminLTE+Bootstrap Table权限管理系统第五节--WBEAPI及SwaggerUI](http://www.jianshu.com/p/b7c8047cbee8)**

**6、[ABP+AdminLTE+Bootstrap Table权限管理系统第六节--abp控制器扩展及json封装](http://www.jianshu.com/p/28f5a29da7d7)**

**7、[ABP+AdminLTE+Bootstrap Table权限管理系统第七节--登录逻辑及abp封装的Javascript函数库](http://www.jianshu.com/p/5002300fcdcd)**

**8、[ABP+AdminLTE+Bootstrap Table权限管理系统第八节--ABP错误机制及AbpSession相关](http://www.jianshu.com/p/bb8044a79227)**

**9、[ABP+AdminLTE+Bootstrap Table权限管理系统第九节--AdminLTE模板页搭建](http://www.jianshu.com/p/40a0d71d3dbd)**

**10、[ABP+AdminLTE+Bootstrap Table权限管理系统第十节--AdminLTE模板菜单处理](http://www.jianshu.com/p/2f0f0ac03615)**

**11、[ABP+AdminLTE+Bootstrap Table权限管理系统第十一节--bootstrap table之用户管理列表](http://www.jianshu.com/p/c802eb1948af)**

**12、[ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统第十二节--小结,Bootstrap Table之角色管理](http://www.jianshu.com/p/9acf68a42313)**

 **13、[ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统第十三节--RBAC模式及ABP权限管理（附送福利）](http://www.jianshu.com/p/65583d63a187)**

 **13、[ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统第十三节--RBAC模式及ABP权限管理（附送福利）](http://www.jianshu.com/p/65583d63a187)**

 **14、[ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统第十四节--后台工作者HangFire与ABP框架Abp.Hangfire及扩展](http://www.jianshu.com/p/ebe390e48479)**

 **15、[ABP module-zero +AdminLTE+Bootstrap Table+jQuery权限管理系统第十五节--缓存小结与ABP框架项目中 Redis Cache的实现](http://www.jianshu.com/p/dae8dd9cc74d)**
未完待续...
运用到的服务端技术:
- [ABP（ASP.NET BolierPlate ProJect）](https://github.com/aspnetboilerplate)
- [Module-Zero](https://github.com/aspnetboilerplate/module-zero)
- [ASP.NET MVC](http://www.asp.net/mvc)
- [ASP.NET Web API](http://www.asp.net/web-api)
- [ASP.NET Identity Framework (and social login extensions)](http://www.asp.net/identity)
- [ASP.NET Web Optimization Framework](http://www.asp.net/mvc/overview/performance/bundling-and-minification)
- [ASP.NET Web Pages](https://docs.microsoft.com/zh-cn/aspnet/web-pages/)
- [SignalR](http://www.asp.net/signalr)
- [EntityFramework](http://www.asp.net/entity-framework)
- [EntityFramework.DynamicFilters](https://github.com/jcachat/EntityFramework.DynamicFilters)
- [Castle Windsor](http://www.castleproject.org/projects/windsor/)
- [AutoMapper](http://automapper.org/)
- [HangFire](http://hangfire.io/)
- [Log4Net](https://logging.apache.org/log4net/)
- [xUnit](https://xunit.github.io/)
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle)
- [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis)
- [SharpZipLib](http://icsharpcode.github.io/SharpZipLib/)
- [System.Linq.Dynamic](https://github.com/kahanu/System.Linq.Dynamic)

客户端:(前端是用的AdminLTE,Bootstrap  table.是开源的,不涉及版权)
- [Twitter Bootstrap](http://getbootstrap.com/)
- [Bootstrap Hover Dropdown](https://github.com/CWSpear/bootstrap-hover-dropdown)
- [Bootstrap Date Range Picker](https://github.com/dangrossman/bootstrap-daterangepicker)
- [Bootstrap Switch](http://www.bootstrap-switch.org/)
- [Bootstrap Select](http://silviomoreto.github.io/bootstrap-select)
- [Bootstrap table](http://bootstrap-table.wenzhixin.net.cn/)
- [jQuery](http://jquery.com/)
- [jQuery UI](http://jqueryui.com/)
- [jQuery BlockUI](http://malsup.com/jquery/block/)
- [jQuery Validation](http://jqueryvalidation.org/)
- [jQuery Ajax Forms](http://malsup.com/jquery/form/)
- [Js Cookie](https://github.com/js-cookie/js-cookie)
- [Modernizr](http://modernizr.com/)
- [Moment.js](http://momentjs.com/)
- [Moment.js Timezone](http://momentjs.com/timezone/)
- [Underscore.js](http://underscorejs.org/)
- [JsTree](https://www.jstree.com/)
- [Respondjs](https://github.com/scottjehl/Respond)
- [Font-Awesome](http://fontawesome.io/)
- [SpinJs](http://fgnass.github.io/spin.js/)
- [SweetAlert](http://t4t5.github.io/sweetalert/)
- [Toastr](http://codeseven.github.io/toastr/)
- [AdminLTE](https://adminlte.io/themes/AdminLTE/index2.html)




