﻿{
    var setNumber = 0;
    $(document).on("click", '.add-set', function (e) {
        e.preventDefault();
        var setclass = `new-set-${setNumber}`;
        $('.set-block').append(`<div class="${setclass}" ></div>`);
        setNumber++;
        // Get the correct partial based on the current exercisetype
        $(`.${setclass}`).load('/Exercises/GetSetPartial', { typeId: $('#exercise-type').val() });
    });

    $(document).on("click", '.remove-set', function (e) {
        e.preventDefault();
        $(this).parent().remove();
    });
}