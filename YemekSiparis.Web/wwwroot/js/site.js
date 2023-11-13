function AllList(id) {
    $.ajax({
        url: "/Basket/AllMenu/" + id,
        type: "GET",
        success: function (response) {
            $("#all-list").html(""),
                $("#all-list").html(response);
              
        }
    })
}

function GetListHamburger() {
    $.ajax({
        url: "/Basket/HamburgerMenu",
        type: "GET",
        success: function (response) {
            $("#HamburgerList").html(response),
                $("#all-list").html(""),
                $("#PizzaList").html(""),
                $("#PastaList").html("");

        }
    })
}


function GetListPizza() {
    $.ajax({
        url: "/Basket/PizzaMenu",
        type: "GET",
        success: function (response) {
            $("#PizzaList").html(response),
                $("#HamburgerList").html(""),
                $("#all-list").html(""),
                $("#PastaList").html("");

        }
    })
}


function GetListPasta(){
    $.ajax({
        url: "/Basket/PastaMenu",
        type: "GET",
        success: function (response) {
            $("#PastaList").html(response),
                $("#all-list").html(""),
                $("#HamburgerList").html(""),
                $("#PizzaList").html("");

        }

    })
}



function TotalPrice(id) {
    let total = {
        foodid:$("#foodid").val(),
        quantity: $("#quantity").val(),
        foodsize: $("#food-size").val(),
        extraid: id,
        beverageid: $("#beverageid").val(),
    }
    $.ajax({
        url: "/Basket/TotalPrice",
        type: "POST",
        data:total,
       
      success: function (response) {
            $("#totalPrice").html(response)
        }
    })


}


function CheckExtra(id, selected) {

    let isSelected = selected.checked;

    let total = {
        foodid: $("#foodid").val(),
        quantity: $("#quantity").val(),
        foodsize: $("#food-size").val(),
        extraid: id,
        isselected: isSelected,
    }

    $.ajax({
        url: "/Basket/TotalPrice",
        type: "POST",
        data: total,

        success: function (response) {
            $("#totalPrice").html(response)
        }
    })
}

function CheckBeverage(id, selected) {

    let isSelected = selected.checked;

    let total = {
        foodid: $("#foodid").val(),
        quantity: $("#quantity").val(),
        foodsize: $("#food-size").val(),
        beverageid: id,
        isselected: isSelected,
    }

    $.ajax({
        url: "/Basket/TotalPrice",
        type: "POST",
        data: total,

        success: function (response) {
            $("#totalPrice").html(response)
        }
    })
}

