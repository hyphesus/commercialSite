const express = require('express');
const mssql = require('mssql');

 html-side
const products = [
    {
        id: 1,
        name: "Product 1",
        description: "This is a description of product 1.",
        price: 19.99,
        image: "images/product1.jpg"
    },
    // ... other product objects
];

// Generate product list dynamically
function renderProducts() {
    const productList = document.querySelector(".products-list");
    productList.innerHTML = "";
    for (const product of products) {
        const productItem = document.createElement("li");
        productItem.innerHTML = `
            <a href="product.html?id=${product.id}">
                <img src="${product.image}" alt="${product.name}">
                <p class="product-name">${product.name}</p>
                <p class="product-price">$${product.price}</p>
            </a>
        `;
        productList.appendChild(productItem);
    }
}

renderProducts();
=======
function tikla() {
    alert('Butona tıkladınız!');

}
function tiklama(){
    alert('butona tiklamasaydin');
}
main
