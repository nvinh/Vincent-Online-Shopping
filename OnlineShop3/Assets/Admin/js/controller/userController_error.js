var user = {
    init: function () {
        user.registerEvents;
        //console.log('1');
    },
    registerEvents: function () {
        console.log('2');
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            console.log('3');
            $.ajax({
                url: "/Admin/User/ChangeStatus",
                data: { id: id },
                type: "json",
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        $(this).text('Active');
                    } else {
                        $(this).text('Blocked');
                    }
                }
            });
        });
    }
}
user.init();
