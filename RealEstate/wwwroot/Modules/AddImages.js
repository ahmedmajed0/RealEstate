$(document).ready(function () {

    document.getElementById("f-img").style.pointerEvents = "none";

    $('#img1').on('change', function () {

        var file = document.getElementById("img1").files;
        if (file.length > 0) {
            var fileReader = new FileReader();
            fileReader.onload = function (event) {
                document.getElementById("f-img").setAttribute("src", event.target.result)
            };

            fileReader.readAsDataURL(file[0]);
        }




        $(this).closest("div").css("background-color", "#FF8084");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img2').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img3').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img4').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img5').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });


    $('#img6').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img7').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img8').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img9').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });


    $('#img10').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img11').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img12').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });


    $('#img13').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img14').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });

    $('#img15').on('change', function () {
        $(this).closest("div").css("background-color", "#FF8084", "color", "white");
        $(this).next("i").css("color", "#FFF");
    });


});