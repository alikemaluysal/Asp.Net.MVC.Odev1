using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Deneme.Models;


namespace Deneme.Controllers
{

    public class UyeController : Controller
    {
        Uye uyeOl = new Uye();


        // GET: Uye
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(Uye uye)
        {

            if (ModelState.IsValid)
            {
                ViewBag.UyeBilgi = $"Üye Adı : {uye.Ad} <hr /> Üye Soyad : {uye.Soyad} <hr /> Üye Mail : {uye.Email} <hr /> Üye TC : {uye.TcKimlikNo}";



                uyeOl.Ad = uye.Ad;
                uyeOl.Soyad = uye.Soyad;
                uyeOl.Email = uye.Email;
                uyeOl.Telefon = uye.Telefon;
                uyeOl.TcKimlikNo = uye.TcKimlikNo;
                uyeOl.DogumTarihi = uye.DogumTarihi;
                uyeOl.KullaniciAdi = uye.KullaniciAdi;
                uyeOl.Sifre = uye.Sifre;


                Session.Add("Oturum", uyeOl);

                //ViewBag.AdSoyadMesaj = "Hoşgeldin " + uyeOl.Ad + " " + uyeOl.Soyad;
            }

            return View(uye);
        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Uye uye)
        {


            if (Session["Oturum"] == null)
            //if (uyeOl == null)
            {
                ViewBag.GirisMesaj = "<div class=\"alert alert-danger\" role=\"alert\" > Üye değilsiniz! Lütfen<a href=\"/Uye/UyeOl\"> üye olun!</a></ div >";

            }

            else if (((Uye)Session["Oturum"]).Email != uye.Email || ((Uye)Session["Oturum"]).Sifre != uye.Sifre)
            //else if (uyeOl.Email != uye.Email || uyeOl.Sifre != uye.Sifre)
            {
                ViewBag.GirisMesaj = "<div class=\"alert alert-danger\" role=\"alert\" >Hatalı mail adresi ya da şifre!</ div >";
            }

            else
            {

                ViewBag.GirisMesaj = "<div class=\"alert alert-success\" role=\"alert\" >Giriş Başarılı!</ div >";

                ViewBag.IsLogged = true;

                //ViewBag.NavbarMesaj = "Hoşgeldin " + ((Uye)Session["Oturum"]).Ad + " " + ((Uye)Session["Oturum"]).Soyad;
                string mesaj2= "Hoşgeldin " + ((Uye)Session["Oturum"]).Ad + " " + ((Uye)Session["Oturum"]).Soyad;
                Session.Add("Mesaj", mesaj2);

                Session.Add("IsLogged", true);



            }
            return View(uyeOl);


        }

        public ActionResult Profil()
        {
            Uye uye2 = (Uye)Session["Oturum"];

            return View(uye2);
        }




        public ActionResult SessionSil()
        {
            Session.Clear();
            return Redirect("/Home/Index");
        }



        public ActionResult AnaSayfaDon()
        {
            return Redirect("/Home/Index");
        }
        public ActionResult GirisDon()
        {
            return Redirect("/Uye/GirisYap");
        }

        public ActionResult UyeOlDon()
        {
            return Redirect("/Uye/UyeOl");
        }










    }
}