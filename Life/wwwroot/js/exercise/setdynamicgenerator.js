{
    var setNumber = 0;
    $(document).on("click", '.add-set', function (e) {
        e.preventDefault();
        addSet(null);
    });

    function addSet(set) {
        var setclass = `new-set-${setNumber}`;
        $('.set-list').append(`<div class="${setclass}" ></div>`);
        setNumber++;
        // Get the correct partial based on the current exercisetype
        $(`.${setclass}`).load('/Exercises/GetSetPartial', { typeId: $('#exercise-type').val(), set: set });
    }

    $(document).on("click", '.remove-set', function (e) {
        e.preventDefault();
        $(this).parent().remove();
    });

}