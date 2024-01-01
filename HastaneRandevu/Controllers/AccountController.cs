using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // Diğer aksiyon metotları

    [HttpPost]
    public ActionResult Login(string username, string password)
    {
        // Kullanıcı girişi kontrolü
        if (IsValidUser(username, password))
        {
            // Admin sayfasına yönlendirme
            return RedirectToAction("Index", "Admin");
        }
        else
        {
            // Giriş başarısızsa uygun işlemleri yapabilirsiniz
            return View("Login");
        }
    }

    private bool IsValidUser(string username, string password)
    {
        // Kullanıcı kimlik doğrulama mantığı buraya eklenir
        // Örneğin, bir veritabanında kullanıcı bilgilerini kontrol edebilirsiniz
        // Bu metotun içeriğini projenizin gereksinimlerine göre uyarlayın

        // Örnek bir kontrol
        return username == "admin" && password == "123456";
    }
}