{
    $(document).ready(function () {
        $.ajax({
            url: "/api/ExercisesInfo",
            type: "POST",
            success: function (data) {
                data = ($.map(data, function (obj, key) {
                    return {
                        label: obj.title,
                        value: obj.title,
                        id: obj.id,
                        type: obj.exerciseType,
                        description: obj.description
                    };
                }));

                $('#info-title').autocomplete({
                    source: data,
                    select: function (event, ui) {
                        //set values
                        $('#exercise-type').val(ui.item.type);
                        $('#description').val(ui.item.description);
                        $('#info-id').val(ui.item.id);

                        $(this).parent()
                            .next()
                            .find('input, textarea, select')
                            .prop('readonly', true);
                    }
                });
            },
            error: function (error) {
            }
        })
    })
}