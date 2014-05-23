﻿using StuffStore.Domain.Abstract;
using StuffStore.Domain.Entities;
using System;
using StuffStore.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuffStore.WebUI.Controllers
{
    public class CartController : Controller {
private IProductRepository repository;
public CartController(IProductRepository repo) {
repository = repo;
}
public ViewResult Index(Cart cart, string returnUrl) {
return View(new CartIndexViewModel {
Cart = cart,
ReturnUrl = returnUrl
});
}
public RedirectToRouteResult AddToCart(Cart cart, int productId,
string returnUrl) {
Product product = repository.Products
.FirstOrDefault(p => p.ProductID == productId);
if (product != null) {
cart.AddItem(product, 1);
}
return RedirectToAction("Index", new { returnUrl });
}
public RedirectToRouteResult RemoveFromCart(Cart cart, int productId,
string returnUrl) {
Product product = repository.Products
.FirstOrDefault(p => p.ProductID == productId);
if (product != null) {
cart.RemoveLine(product);
}
return RedirectToAction("Index", new { returnUrl });
}
public PartialViewResult Summary(Cart cart)
{
    return PartialView(cart);
}

[HttpPost]
public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
{
    if (cart.Lines.Count() == 0)
    {
        ModelState.AddModelError("", "Sorry, your cart is empty!");
    }
    if (ModelState.IsValid)
    {
        
        return View("Completed");
    }
    else
    {
        return View(shippingDetails);
    }
}

public ViewResult Checkout()
{
    return View(new ShippingDetails());
}

}
    }
