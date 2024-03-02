function getCartItem(orderId) {
    $.ajax({
        type: 'POST',
        url: '/Orders?handler=ShowCartItem', // Replace with the actual path to your Razor Page method
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(orderId),
        success: function (response) {
            if (response.result == 'OK') {
                showCartMode(response.listCartItem);
                console.log(response.listCartItem);
            }

        },
        error: function (error) {
            console.error('Error submitting form:', error);
        }
    });


}

function showCartMode(shoppingCart) {
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

    var cartModal = new bootstrap.Modal(document.getElementById('cartModal'));
    cartModal.show();
}

function getListOrderPaging(pageNumer) {
    $.ajax({
        url: '/Orders?handler=GetOrderListPaging', // Replace with your actual controller and action
        type: 'POST',
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(pageNumer),
        success: function (partialHtml) {
            // Update the content of the partial container
            $('#orderListPartial').html(partialHtml);
        },
        error: function (error) {
            console.error('Error loading partial:', error);
        }
    });
}

function search() {
    var searchText = document.getElementById('searchText').value;
    if (searchText % 1 !== 0) {
        showOutOfStockToastDanger("Warning", "PLease enter number to search order");
        return;
    }

    $.ajax({
        url: '/Orders?handler=SearchById', // Replace with your actual controller and action
        type: 'POST',
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(searchText),
        success: function (partialHtml) {
            // Update the content of the partial container
            $('#orderListPartial').html(partialHtml);
        },
        error: function (error) {
            console.error('Error loading partial:', error);
        }
    });
}

