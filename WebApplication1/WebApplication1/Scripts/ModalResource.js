    /*
    Criador:Felipe Catto
    Objetivo: pega o evendo onclick, vai até a PartialView e é rederizado em alguma vieww
    */


        var script = document.createElement("SCRIPT");
        script.src = 'https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js';
        script.type = 'text/javascript';
        script.onload = function () {
            var $ = window.jQuery;
            // Use $ here...
        };
        document.getElementsByTagName("head")[0].appendChild(script);

    function renderPartialToView1(Controller, Action, param1) {
        debugger;
        //e.preventDefault();
        $.ajax({
            method: "GET",
            url: "/" + Controller + "/" + Action + "",
            data: { estampa: param1},
            cache: false
        }).success(function (data) {
            $("#result").html(data);
        });
    }


