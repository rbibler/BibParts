$(function () {

    var addInstance = function () {
        console.log("HEY!");
    }

    $(".main-content").on("click", "fa fa-minus-circle", addInstance);
});