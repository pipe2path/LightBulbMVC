$('#btnProcess').click(function () {
    var people = $('#numOfPeople').val();
    var bulbs = $('#numOfBulbs').val()

    $.post("@Url.Action("Process", "LightBulb")", new { people: people, bulbs: bulbs }, function () {
        // nothing happens here
    })
})
