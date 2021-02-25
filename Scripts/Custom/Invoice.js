var invoices = [];

$(document).ready(function () {
    invoices = [];
    loadData();
});


//Load Data function  
function loadData() {
    $.ajax({
        url: "/Invoice/GetInvoices",
        type: "POST",
        dataType: "json",
        success: function (result) {

            var index = 1;
            var html = '';
            result.forEach(item => {
                html += '<tr>';
                html += '<td>' + index + '</td>';
                html += '<td>' + item.InvoiceNumber + '</td>';
                html += '<td>' + item.Product + '</td>';
                html += '<td>' + item.Quantity + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '</tr>';
                index++;
            });
            $('#mainTableTBody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function AddDataToInvoice() {
    debugger;
var res = validate();
    if (res == false) {
        return false;
    }
    var invoice = {
        Product: $('#Product').val(),
        Quantity: $('#Quantity').val(),
        Price: $('#Price').val(),
    };
    invoices.push(invoice);

    var html = '';
    html += '<tr>';
    html += '<td>' + invoices.length + '</td>';
    html += '<td>' + invoice.Product + '</td>';
    html += '<td>' + invoice.Quantity + '</td>';
    html += '<td>' + invoice.Price + '</td>';
    html += '</tr>';

    $("#invoiceDataTBody").append(html);
    clearTextBox()
}

//Add Data Function
function Add() {
    debugger;
    if (invoices != null || invoices != undefined) {
        $.ajax({
            url: "/Invoice/AddInvoice",
            data: { invoices:invoices },
            type: "POST",
            dataType: "json",
            success: function (result) {
                invoices = [];
                if (result != 0) {
                    loadData();
                    $('#myModal').modal('hide');
                } else {
                    alert("Invoice Not Added! Something went wrong!")
                }


            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
  
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#ID').val("");
    $('#Product').val("");
    $('#Quantity').val("");
    $('#Price').val("");
    
    $('#Product').css('border-color', 'lightgrey');
    $('#Quantity').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
}

//Validation using jquery  
function validate() {
    var isValid = true;
    if ($('#Product').val().trim() == "") {
        $('#Product').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Product').css('border-color', 'lightgrey');
    }
    if ($('#Quantity').val().trim() == "") {
        $('#Quantity').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Quantity').css('border-color', 'lightgrey');
    }
    if ($('#Price').val() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Price').css('border-color', 'lightgrey');
    }
   
    return isValid;
}
