-> ​Go to NuGet Packages and install "Microsoft.AspNetCore.Session"

Now, We can use the session by following the below codes.

1) First we need to add a session to builder as below

builder.Services.AddSession();

2) Now add a session in app section to configure the HTTP request pipeline.

app.UseSession();

3) Finally Program.cs class look like this

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())

{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(

    name: "default",

    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

4) How to set Session

 public IActionResult Index()

        {

            // set session as string

            HttpContext.Session.SetString("LoginUser", "Adi");  

            // set session as int

            HttpContext.Session.SetInt32("LoginUserId", 101);

            //Set Object as JSON from Session

            // some object

            object value = new object();

            // set object value in session

            HttpContext.Session.SetString("Key Name", JsonConvert.SerializeObject(value));

            return View();

        }

5) How to get Session

        public IActionResult Privacy()

        {

            // get string session

            var loginUser = HttpContext.Session.GetString("LoginUser");

            //get int session

            var loginUserId = HttpContext.Session.GetInt32("LoginUserId");



            //Get Object as JSON from Session

            // get object value in session

            object value = new object();

            var sesionValue = HttpContext.Session.GetString("Key Name");

            var sessionObj = value == null ? default(T) : JsonConvert.DeserializeObject<T>(sesionValue);



            return View();

        }

Ref: ​Code Reference

Code in Git:​https://github.com/adi501/How-To-Use-Session-In-.NET-Core​​​
