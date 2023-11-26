<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="SCart.ViewProduct" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="SCart.ViewProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>AdminLTE 3 | E-commerce</title>

<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback">

<link rel="stylesheet" href="../../plugins/fontawesome-free/css/all.min.css">

<link rel="stylesheet" href="../../dist/css/adminlte.min.css?v=3.2.0">
<script defer="" referrerpolicy="origin" src="/cdn-cgi/zaraz/s.js?z=JTdCJTIyZXhlY3V0ZWQlMjIlM0ElNUIlNUQlMkMlMjJ0JTIyJTNBJTIyQWRtaW5MVEUlMjAzJTIwJTdDJTIwRS1jb21tZXJjZSUyMiUyQyUyMnglMjIlM0EwLjM5NzcwMzk0NjI3NzgyNzM1JTJDJTIydyUyMiUzQTE1MzYlMkMlMjJoJTIyJTNBODY0JTJDJTIyaiUyMiUzQTc0NyUyQyUyMmUlMjIlM0ExNTM2JTJDJTIybCUyMiUzQSUyMmh0dHBzJTNBJTJGJTJGYWRtaW5sdGUuaW8lMkZ0aGVtZXMlMkZ2MyUyRnBhZ2VzJTJGZXhhbXBsZXMlMkZlLWNvbW1lcmNlLmh0bWwlMjIlMkMlMjJyJTIyJTNBJTIyaHR0cHMlM0ElMkYlMkZhZG1pbmx0ZS5pbyUyRnRoZW1lcyUyRnYzJTJGJTIyJTJDJTIyayUyMiUzQTI0JTJDJTIybiUyMiUzQSUyMlVURi04JTIyJTJDJTIybyUyMiUzQS0zMzAlMkMlMjJxJTIyJTNBJTVCJTVEJTdE"></script><script nonce="d39cbc24-cf9d-47c8-91f6-6e0a7ff9a10c">(function(w,d){!function(a,b,c,d){a[c]=a[c]||{};a[c].executed=[];a.zaraz={deferred:[],listeners:[]};a.zaraz.q=[];a.zaraz._f=function(e){return async function(){var f=Array.prototype.slice.call(arguments);a.zaraz.q.push({m:e,a:f})}};for(const g of["track","set","debug"])a.zaraz[g]=a.zaraz._f(g);a.zaraz.init=()=>{var h=b.getElementsByTagName(d)[0],i=b.createElement(d),j=b.getElementsByTagName("title")[0];j&&(a[c].t=b.getElementsByTagName("title")[0].text);a[c].x=Math.random();a[c].w=a.screen.width;a[c].h=a.screen.height;a[c].j=a.innerHeight;a[c].e=a.innerWidth;a[c].l=a.location.href;a[c].r=b.referrer;a[c].k=a.screen.colorDepth;a[c].n=b.characterSet;a[c].o=(new Date).getTimezoneOffset();if(a.dataLayer)for(const n of Object.entries(Object.entries(dataLayer).reduce(((o,p)=>({...o[1],...p[1]})),{})))zaraz.set(n[0],n[1],{scope:"page"});a[c].q=[];for(;a.zaraz.q.length;){const q=a.zaraz.q.shift();a[c].q.push(q)}i.defer=!0;for(const r of[localStorage,sessionStorage])Object.keys(r||{}).filter((t=>t.startsWith("_zaraz_"))).forEach((s=>{try{a[c]["z_"+s.slice(7)]=JSON.parse(r.getItem(s))}catch{a[c]["z_"+s.slice(7)]=r.getItem(s)}}));i.referrerPolicy="origin";i.src="/cdn-cgi/zaraz/s.js?z="+btoa(encodeURIComponent(JSON.stringify(a[c])));h.parentNode.insertBefore(i,h)};["complete","interactive"].includes(b.readyState)?zaraz.init():a.addEventListener("DOMContentLoaded",zaraz.init)}(w,d,"zarazData","script");})(window,document);</script></head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="card-body">
<div class="row">
<div class="col-12 col-sm-6">
<h3 class="d-inline-block d-sm-none">LOWA Men’s Renegade GTX Mid Hiking Boots Review</h3>
<div class="col-12">
    <asp:Image ID="ImageProduct" runat="server" />
</div>
<div class="col-12 product-image-thumbs">
<div class="product-image-thumb active"><img src="../../dist/img/prod-1.jpg" alt="Product Image"></div>
<div class="product-image-thumb"><img src="../../dist/img/prod-2.jpg" alt="Product Image"></div>
<div class="product-image-thumb"><img src="../../dist/img/prod-3.jpg" alt="Product Image"></div>
<div class="product-image-thumb"><img src="../../dist/img/prod-4.jpg" alt="Product Image"></div>
<div class="product-image-thumb"><img src="../../dist/img/prod-5.jpg" alt="Product Image"></div>
</div>
</div>
<div class="col-12 col-sm-6">
<h3 class="my-3">
    <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></h3>
<p>
    <asp:Label ID="lblSD" runat="server" Text=""></asp:Label></p>
<hr>
<h4>Available Colors</h4>
<div class="btn-group btn-group-toggle" data-toggle="buttons">
<label class="btn btn-default text-center active">
<input type="radio" name="color_option" id="color_option_a1" autocomplete="off" checked="">
Green
<br>
<i class="fas fa-circle fa-2x text-green"></i>
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_a2" autocomplete="off">
Blue
<br>
<i class="fas fa-circle fa-2x text-blue"></i>
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_a3" autocomplete="off">
Purple
<br>
<i class="fas fa-circle fa-2x text-purple"></i>
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_a4" autocomplete="off">
Red
<br>
<i class="fas fa-circle fa-2x text-red"></i>
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_a5" autocomplete="off">
Orange
<br>
<i class="fas fa-circle fa-2x text-orange"></i>
</label>
</div>
<h4 class="mt-3">Size <small>Please select one</small></h4>
<div class="btn-group btn-group-toggle" data-toggle="buttons">
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_b1" autocomplete="off">
<span class="text-xl">S</span>
<br>
Small
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_b2" autocomplete="off">
<span class="text-xl">M</span>
<br>
Medium
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_b3" autocomplete="off">
<span class="text-xl">L</span>
<br>
Large
</label>
<label class="btn btn-default text-center">
<input type="radio" name="color_option" id="color_option_b4" autocomplete="off">
<span class="text-xl">XL</span>
<br>
Xtra-Large
</label>
</div>
<div class="bg-gray py-2 px-3 mt-4">
<h2 class="mb-0">
    <asp:Label ID="lblPrice" runat="server" Text="$"></asp:Label>
</h2>
<h4 class="mt-0">
<small>
    <asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label></small>
</h4>
</div>
<div class="mt-4">
<div class="btn btn-primary btn-lg btn-flat">
<i class="fas fa-cart-plus fa-lg mr-2"></i>
Add to Cart
</div>
<div class="btn btn-default btn-lg btn-flat">
Add to Wishlist
</div>
</div>
<div class="mt-4 product-share">

<a href="#" class="text-gray">
<i class="fab fa-facebook-square fa-2x"></i>
</a>
<a href="#" class="text-gray">
<i class="fab fa-twitter-square fa-2x"></i>
</a>
<a href="#" class="text-gray">
<i class="fas fa-envelope-square fa-2x"></i>
</a>
<a href="#" class="text-gray">
<i class="fas fa-rss-square fa-2x"></i>
</a>
</div>
</div>
</div>
<div class="row mt-4">
<nav class="w-100">
<div class="nav nav-tabs" id="product-tab" role="tablist">
<a class="nav-item nav-link active" id="product-desc-tab" data-toggle="tab" href="#product-desc" role="tab" aria-controls="product-desc" aria-selected="true">Description</a>
<a class="nav-item nav-link" id="product-comments-tab" data-toggle="tab" href="#product-comments" role="tab" aria-controls="product-comments" aria-selected="false">Comments</a>
<a class="nav-item nav-link" id="product-rating-tab" data-toggle="tab" href="#product-rating" role="tab" aria-controls="product-rating" aria-selected="false">Rating</a>
</div>
</nav>
<div class="tab-content p-3" id="nav-tabContent">
<div class="tab-pane fade show active" id="product-desc" role="tabpanel" aria-labelledby="product-desc-tab"> <asp:Label ID="lblLD" runat="server" Text=""></asp:Label> </div>
<div class="tab-pane fade" id="product-comments" role="tabpanel" aria-labelledby="product-comments-tab">
    <asp:Label ID="lblProductId" Visible="false" runat="server" Text=""></asp:Label> </div>
<div class="tab-pane fade" id="product-rating" role="tabpanel" aria-labelledby="product-rating-tab"> Cras ut ipsum ornare, aliquam ipsum non, posuere elit. In hac habitasse platea dictumst. Aenean elementum leo augue, id fermentum risus efficitur vel. Nulla iaculis malesuada scelerisque. Praesent vel ipsum felis. Ut molestie, purus aliquam placerat sollicitudin, mi ligula euismod neque, non bibendum nibh neque et erat. Etiam dignissim aliquam ligula, aliquet feugiat nibh rhoncus ut. Aliquam efficitur lacinia lacinia. Morbi ac molestie lectus, vitae hendrerit nisl. Nullam metus odio, malesuada in vehicula at, consectetur nec justo. Quisque suscipit odio velit, at accumsan urna vestibulum a. Proin dictum, urna ut varius consectetur, sapien justo porta lectus, at mollis nisi orci et nulla. Donec pellentesque tortor vel nisl commodo ullamcorper. Donec varius massa at semper posuere. Integer finibus orci vitae vehicula placerat. </div>
</div>
</div>
</div>
        </div>
    </form>
</body>
</html>
