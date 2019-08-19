$(document).ready(function () {
    loadData();
});

function search() {
    var value = $('#pesquisa').val().toLowerCase();
    $("#myTable tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
}

function loadData() {
    $.ajax({
        url: "https://localhost:44311/Product",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + new Date(item.dataLancamento).toLocaleDateString() + '</td>';
                html += '<td>' + item.nome + '</td>';
                html += '<td>' + item.tipoProduto + '</td>';
                html += '<td>' + item.valor + '</td>';
                html += '<td><a href="#" onclick="return getbyID(\'' + item.id + '\')">Editar</a> | <a href="#" onclick="Delele(\'' + item.id + '\')">Excluir</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        DataLancamento: $('#dataLancamento').val(),
        Nome: $('#nome').val(),
        TipoProduto: $('#tipoProduto').val(),
        Valor: $('#valor').val(),
    };
    $.ajax({
        url: "https://localhost:44311/Product",
        data: JSON.stringify(productObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(ID) {
    $('#dataLancamento').css('border-color', 'lightgrey');
    $('#nome').css('border-color', 'lightgrey');
    $('#tipoProduto').css('border-color', 'lightgrey');
    $('#valor').css('border-color', 'lightgrey');
    $.ajax({
        url: "https://localhost:44311/Product/" + ID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ProductID').val(result.id);
            $('#dataLancamento').val(new Date(result.dataLancamento).toISOString().slice(0, 10));
            $('#nome').val(result.nome);
            $('#tipoProduto').val(result.tipoProduto);
            $('#valor').val(result.valor);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        Id: $('#ProductID').val(),
        DataLancamento: $('#dataLancamento').val(),
        Nome: $('#nome').val(),
        TipoProduto: $('#tipoProduto').val(),
        Valor: $('#valor').val(),
    };
    $.ajax({
        url: "https://localhost:44311/Product",
        data: JSON.stringify(productObj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ProductID').val("");
            $('#dataLancamento').val("");
            $('#nome').val("");
            $('#tipoProduto').val("");
            $('#valor').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(ID) {
    var ans = confirm("Deseja realmente excluir este produto?");
    if (ans) {
        $.ajax({
            url: "https://localhost:44311/Product?id=" + ID,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "text",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#ProductID').val("");
    $('#dataLancamento').val("");
    $('#nome').val("");
    $('#tipoProduto').val("");
    $('#valor').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#dataLancamento').css('border-color', 'lightgrey');
    $('#nome').css('border-color', 'lightgrey');
    $('#tipoProduto').css('border-color', 'lightgrey');
    $('#valor').css('border-color', 'lightgrey');
}

function validate() {
    var isValid = true;
    if ($('#dataLancamento').val().trim() == "") {
        $('#dataLancamento').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#dataLancamento').css('border-color', 'lightgrey');
    }
    if ($('#nome').val().trim() == "") {
        $('#nome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#nome').css('border-color', 'lightgrey');
    }
    if ($('#tipoProduto').val().trim() == "") {
        $('#tipoProduto').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#tipoProduto').css('border-color', 'lightgrey');
    }
    if ($('#valor').val().trim() == "") {
        $('#valor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#valor').css('border-color', 'lightgrey');
    }
    return isValid;
}