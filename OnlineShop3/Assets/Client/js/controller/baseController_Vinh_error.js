var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function( request, response ) {
                $.ajax({
                    url: "/Product/ListName",
                    dataType: "jsonp",
                    data: {
                        q: request.term
                    },
                    success: function( res ) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                //$("#txtKeyword-id").val(ui.item.value);
                //$("#txtKeyword-description").html(ui.item.desc);
                //$("#txtKeyword-icon").attr("src", "images/" + ui.item.icon);
                return false;
            }
        })
    .autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
          .append("<a>" + item.label + "</a>")
          .appendTo(ul);
    };
    }
}
common.init();