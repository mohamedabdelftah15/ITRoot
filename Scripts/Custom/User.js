var userType = "";
$(document).ready(function () {
    loadData();
    getRoleList();
});

function getRoleList() {
    $.ajax({
        type: "POST",
        url: "/User/GetRoles",
        dataType: "json",
        success: function (res) {
            res.forEach(e => {
                $("#Role_ID").append("<option value=" + e.ID + ">" + e.RoleName + "</option>");
            });
        }

    });
}

//Search for users
function search() {
    var searchValue = $("#searchValue").val();
    $.ajax({
        type: "POST",
        url: "/User/SearchUsers",
        dataType: "json",
        data: { searchValue:searchValue },
        success: function (result) {
            var index = 1;
            var html = '';
            result.forEach(item => {
                html += '<tr>';
                html += '<td>' + index + '</td>';
                html += '<td>' + item.FullName + '</td>';
                html += '<td>' + item.UserName + '</td>';
                html += '<td>' + item.Password + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.Phone + '</td>';
                html += '<td class="userType"><button class="btn btn-primary" onclick="return getbyID(' + item.ID + ')">Edit</button>  <button class="btn btn-danger" onclick="Delete(' + item.ID + ')">Delete</button></td>';
                html += '</tr>';
                index++;
            });
            $('tbody').html(html);
            userType = sessionStorage.getItem("UserType");
            if (userType == "User") {
                $(".userType").hide();
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Load Data function  
function loadData() {
    $.ajax({
        url: "/User/GetUsers",
        type: "POST",
        dataType: "json",
        success: function (result) {
            
            var index = 1;
            var html = '';
            result.forEach(item => {
                html += '<tr>';
                html += '<td>' + index + '</td>';
                html += '<td>' + item.FullName + '</td>';
                html += '<td>' + item.UserName + '</td>';
                html += '<td>' + item.Password + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.Phone + '</td>';
                html += '<td class="userType"><button class="btn btn-primary" onclick="return getbyID(' + item.ID + ')">Edit</button>  <button class="btn btn-danger" onclick="Delete(' + item.ID + ')">Delete</button></td>';
                html += '</tr>';
                index++;
            });
            $('tbody').html(html);
            userType = sessionStorage.getItem("UserType");
            if (userType == "User") {
                $(".userType").hide();
            }
           
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var user = {
        //ID: $('#ID').val(),
        FullName: $('#FullName').val(),
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
        Email: $('#Email').val(),
        Phone: $('#Phone').val(),
        RoleID: $('#Role_ID').val(),
    };
    $.ajax({
        url: "/User/AddOrEditUser",
        data: user,
        type: "POST",
        dataType: "json",
        success: function (result) {
            if (result!=0) {
                loadData();
                $('#myModal').modal('hide');
            } else {
                alert("User Not Added! Exist User have one or more from your data.You need to change (User Name or Email or Phone).")
            }

            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(ID) {
    $('#FullName').css('border-color', 'lightgrey');
    $('#UserName').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Phone').css('border-color', 'lightgrey');
    $('#Role_ID').css('border-color', 'lightgrey');
    $.ajax({
        url: "/User/GetUserByID",
        type: "POST",
        dataType: "json",
        data: {id: ID },
        success: function (result) {
            if (result!=null) {
                console.log(result);
                $('#ID').val(result.ID);
                $('#FullName').val(result.FullName);
                $('#UserName').val(result.UserName);
                $('#Password').val(result.Password);
                $('#Email').val(result.Email);
                $('#Phone').val(result.Phone);
                $('#Role_ID').val(result.RoleID);

                $('#myModal').modal('show');
                $('#btnUpdate').show();
                $('#btnAdd').hide();
                $("#myModalLabel").text("Edit User");
            } else {
                alert("User Not Found!")
            }
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var user = {
        ID: $('#ID').val(),
        FullName: $('#FullName').val(),
        UserName: $('#UserName').val(),
        Password: $('#Password').val(),
        Email: $('#Email').val(),
        Phone: $('#Phone').val(),
        RoleID: $('#Role_ID').val(),
    };
    $.ajax({
        url: "/User/AddOrEditUser",
        data: user,
        type: "POST",
        dataType: "json",
        success: function (result) {
            
            if (result!=0) {
                loadData();
                $('#myModal').modal('hide');
                $('#ID').val("");
                $('#FullName').val("");
                $('#UserName').val("");
                $('#Password').val("");
                $('#Email').val("");
                $('#Phone').val("");
                $('#Role_ID').val("");
            } else {
                alert("Edit User is Failed!")
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/User/DeleteUser",
            type: "POST",
            dataType: "json",
            data: { id: ID },
            success: function (result) {
                if (result!=0) {
                    loadData();
                } else {
                    alert("Delete User is Failed!");
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
    $('#FullName').val("");
    $('#UserName').val("");
    $('#Password').val("");
    $('#Email').val("");
    $('#Phone').val("");
    $('#Role_ID').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#FullName').css('border-color', 'lightgrey');
    $('#UserName').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Phone').css('border-color', 'lightgrey');
    $('#Role_ID').css('border-color', 'lightgrey');
    $("#myModalLabel").text("Add User");
}

//Validation using jquery  
function validate() {
    var isValid = true;
    if ($('#FullName').val().trim() == "") {
        $('#FullName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#FullName').css('border-color', 'lightgrey');
    }
    if ($('#UserName').val().trim() == "") {
        $('#UserName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#UserName').css('border-color', 'lightgrey');
    }
    if ($('#Password').val() == "") {
        $('#Password').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Password').css('border-color', 'lightgrey');
    }
    if ($('#Email').val() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
        var email = $('#Email').val();
        const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
         
        if (!re.test(email)) {
            $('#EmailError').html('Write Valid Email,please!');
            isValid = false;
        }
        else {
            $('#EmailError').html('');
        }
    }
    
    if ($('#Phone').val() == "") {
        $('#Phone').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Phone').css('border-color', 'lightgrey');
    }
    if ($('#Role_ID').val() == "" || $('#Role_ID').val() == null || $('#Role_ID').val() == undefined) {
        $('#Role_ID').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Role_ID').css('border-color', 'lightgrey');
    }
    return isValid;
}

//Log In Success Function
function LogInSuccess(result) {
    
    if (result.Value != "") {
        var userRole = result.Value.RoleName;
        if (userRole == "User") {
            sessionStorage.setItem("UserType", "User");
        } else {
            sessionStorage.setItem("UserType", "Admin");
        }
        location.href = "/User/Index";
    } else {
        alert(result.Message)
    }
}

//Register Success Function
function RegisterSuccess(result) {
    if (result) {
        alert("Check your email for verfication, please!");
    } else {
        alert("Registeration Failed! Exist User have one or more from your data.You need to change (User Name or Email or Phone).")
    }
}

//Validate LogIn Fields
function logInValidate() {
    
    var valid = true;
    var roleID = $("#RoleID").val();
    if (roleID == "0" || roleID == 0|| roleID == "" || roleID == null || roleID == undefined) {
        valid = false;
        $("#RoleIDError").html("User Type is required!")
    } else {
        valid = true;
        $("#RoleIDError").html("")
    }
    if (valid == true) {
        $("#logInSubmit").submit();
    }
}

