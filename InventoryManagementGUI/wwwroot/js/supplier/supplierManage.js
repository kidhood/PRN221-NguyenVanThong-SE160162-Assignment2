function getListPagingManager(pageNumber) {
    $.ajax({
        url: '/ManageSupplier?handler=GetSupplierListPaging', // Replace with your actual controller and action
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
        url: '/ManageSupplier?handler=SearchByName', // Replace with your actual controller and action
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

function openEditModal(productId, productName, productImagePath, productQuantity, productDescription) {
    document.getElementById('productId').value = productId;
    document.getElementById('productName').value = productName;
    document.getElementById('productImagePath').value = productImagePath;
    document.getElementById('productQuantity').value = productQuantity;
    document.getElementById('productDescription').value = productDescription;
    $('#editProductModal').modal('show');
}

function saveSupplierChanges() {
    var form = document.forms.namedItem("myForm");
    var data = new FormData(form);

    $.ajax({
        url: '/ManageSupplier?handler=CreateSupplier',
        type: 'POST',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: data,
        processData: false,  // Don't process the data (already FormData)
        contentType: false,  // Don't set contentType (let jQuery handle it)
        success: function (response) {
            // Update the content of the partial container
            if (response.result == 'Ok') {
                if (response.data == 'add') {
                    showOutOfStockToastSuccess("Announce", "Create supplier successfully");
                } else {
                    showOutOfStockToastSuccess("Announce", "Update supplier successfully");
                }
                // Close the modal
                $('#editProductModal').modal('hide');
                getListPagingManager(1);
            } else {
                $('#editProductModal .modal-body').html(response);
                $('#editProductModal').modal('show');
            }
        },
        error: function (error) {
            showOutOfStockToastDanger("Announce", "Create supplier fail");
            console.error('Error loading partial:', error);
        }
    });
}

function confirmDeleteProduct(id) {
    var confirmDelete = window.confirm("Are you sure you want to delete this supplier?");

    if (confirmDelete) {
        deleteProduct(id);
    }
}

function deleteProduct(id) {
    document.getElementById('productId').value = id;
    var form = document.forms.namedItem("myForm");
    var data = new FormData(form);

    $.ajax({
        url: '/ManageSupplier?handler=DeleteSupplier',
        type: 'POST',
        headers: {
            RequestVerificationToken: $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: data,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.result == 'Ok') {
                showOutOfStockToastSuccess("Announce", "Delete supplier successfully");
                getListPagingManager(1);
            } else {
                showOutOfStockToastSuccess("Announce", "Delete supplier fail");
            }
        },
        error: function (error) {
            showOutOfStockToastDanger("Announce", "Delete supplier failed");
        }
    });
}

function updateSupplierId() {
    var selectedValue = document.getElementById('supplierSelect').value;
    document.getElementById('supplierId').value = selectedValue;
}

