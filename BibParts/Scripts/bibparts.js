$(function () {

    var addInstance = function () {
        var $elementClicked = $(this);
        var partId = $elementClicked.attr("data-bp-partid");
        var addOrRemove = $elementClicked.attr("data-bp-addremoveaction");
        var options = {
            url: "",
            type: "get"
        };
            options.url = "/parts/" + addOrRemove + "instance/?id=" + partId;

        $.ajax(options).done(function (data) {
            var target = $elementClicked.parents("div.listView").attr("data-bibpart-target");
            $(target).replaceWith(data);
        });
        return false;
    };

    $(".body-content").on("click", ".values i", addInstance);
});