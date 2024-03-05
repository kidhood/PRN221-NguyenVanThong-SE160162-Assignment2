// Shopping cart array to store products
var shoppingCart = [];

function addToCart(productId, productName, productQuantity, productPrice, productImage) {
    // Check if the product is already in the cart
    var existingProduct = shoppingCart.find(item => item.productId === productId);

    if (existingProduct) {
        // If the product is already in the cart, increase its quantity
        if (productQuantity <= existingProduct.quantity) {
            showOutOfStockToastDanger("Announcement", "Product\'s selected out of stock");
        } else {
            existingProduct.quantity += 1;
        }
    } else {
        // If the product is not in the cart, add it with quantity 1
        if (productQuantity == 0) {
            showOutOfStockToastDanger("Announcement", "Product\'s selected out of stock");
            return;
        }
        var newProduct = {
            productId: productId,
            productName: productName,
            quantity: 1,
            price: parseFloat(productPrice),
            productImage: productImage
        };

        shoppingCart.push(newProduct);
        console.log(shoppingCart);
        updateCartBadge();
    }
}

function removeFromCart(productId) {
    // Find the index of the item with the specified product ID
    const index = shoppingCart.findIndex(item => item.productId === productId);

    // If the item is found, remove it from the array
    if (index !== -1) {
        shoppingCart.splice(index, 1);
        updateCartModal(); // Update the modal or UI after removing the item
        updateCartBadge(); // Update the cart badge
    }
}

function updateCartBadge() {
    // Update the cart badge count
    var cartBadge = document.getElementById('cartBadge');
    if (cartBadge) {
        cartBadge.textContent = shoppingCart.length.toString();
    }
}

function updateCartModal() {
    var cartTableBody = document.getElementById('cartTableBody');
    var totalQuantityElement = document.getElementById('totalQuantity');
    var totalPriceElement = document.getElementById('totalPrice');

    // Clear existing content
    cartTableBody.innerHTML = '';
    var totalQuantity = 0;
    var totalPrice = 0;

    // Add new content based on the shoppingCart array
    shoppingCart.forEach(item => {
        var row = document.createElement('tr');
        row.innerHTML = `
                      <td class="align-middle text-center">${item.productId}</td>
                      <td class="align-middle text-center"><img src="${item.productImage}" class="avatar avatar-sm me-3 border-radius-lg"></td>
                      <td class="align-middle text-center">${item.productName}</td>
                      <td class="align-middle text-center">${item.quantity}</td>
                      <td class="align-middle text-center">${item.price}</td>
                      <td class="align-middle text-center text-danger " onclick="removeFromCart('${item.productId}')"  style="cursor: pointer;">
                        <i class="material-icons opacity-10">delete</i>
                      </td>
                  `;
        cartTableBody.appendChild(row);

        totalQuantity += item.quantity;
        totalPrice += item.quantity * item.price;
    });

    if (totalQuantityElement) {
        totalQuantityElement.textContent = totalQuantity.toString();
    }

    if (totalPriceElement) {
        totalPriceElement.textContent = totalPrice.toFixed(2) + ' $'; // Format total price with 2 decimal places
    }
}

// Function to show the cart modal
function showCartModal() {
    updateCartModal(); // Update the content before showing
    var cartModal = new bootstrap.Modal(document.getElementById('cartModal'));
    cartModal.show();
}

function orderProduct() {

    // Send AJAX request to handle form submission
    $.ajax({
        type: 'POST',
        url: '/Products?handler=OrderForm', // Replace with the actual path to your Razor Page method
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(shoppingCart),
        success: function (response) {
            showOutOfStockToastSuccess("Announcement", "Order Successfully");
            shoppingCart = [];
            updateCartBadge();
            // Close the modal
            $('#cartModal').modal('hide');
        },
        error: function (error) {
            console.error('Error submitting form:', error);
        }
    });
}


function getListPaging(pageNumber) {
    $.ajax({
        url: '/Products?handler=GetProductListPaging', // Replace with your actual controller and action
        type: 'POST',
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(pageNumber),
        success: function (partialHtml) {
            // Update the content of the partial container
            $('#listPartial').html(partialHtml);
        },
        error: function (error) {
            console.error('Error loading partial:', error);
        }
    });
}

function search() {
    var searchText = document.getElementById('searchText').value;

    $.ajax({
        url: '/Products?handler=SearchByName', // Replace with your actual controller and action
        type: 'POST',
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(searchText),
        success: function (partialHtml) {
            // Update the content of the partial container
            $('#listPartial').html(partialHtml);
        },
        error: function (error) {
            console.error('Error loading partial:', error);
        }
    });
}