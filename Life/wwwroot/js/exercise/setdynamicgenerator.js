{
    var setNumber = 0;
    $(document).on("click", '.add-set', function (e) {
        e.preventDefault();
        var setclass = `new-set-${setNumber}`;
        $('.set-list').append(`<div class="${setclass}" ></div>`);
        setNumber++;
        // Get the correct partial based on the current exercisetype
        $(`.${setclass}`).load('/Exercises/GetSetPartial', { typeId: $('#exercise-type').val() });
    });

    $(document).on("click", '.remove-set', function (e) {
        e.preventDefault();
        $(this).parent().remove();
    });

    $('#create-exercise').submit(function (e) {
       e.preventDefault();
       console.log("trying to submit form");
        var input = $(this).serializeArray();

        $.post({
            url: "/Exercises/Create",
            data: input
        });

     });
}