{
    $(document).ready(function () {
        $.ajax({
            url: "/api/ExercisesInfo",
            type: "POST",
            success: function (data) {
                data = ($.map(data, function (obj, key) {
                    return {
                        label: obj.title,
                        value: obj.title
                    };
                }));

                $('#info-title').autocomplete({
                    source: data
                });
            },
            error: function (error) {
            }
        })
    })
}