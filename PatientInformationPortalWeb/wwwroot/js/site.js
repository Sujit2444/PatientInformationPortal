 $(document).ready(function () {
        $("#addNCDButton").on('click', function (e) {
            e.preventDefault();
            let selectedItems = $("#leftNCDs option:selected");
            selectedItems.detach().appendTo("#rightNCDs");
        });

    $("#removeNCDButton").on('click', function (e) {
        e.preventDefault();
    let selectedItems = $("#rightNCDs option:selected");
    selectedItems.detach().appendTo("#leftNCDs");
        });

    $("#addAlButton").on('click', function (e) {
        e.preventDefault();
    let selectedItems = $("#leftAllergies option:selected");
    selectedItems.detach().appendTo("#rightAllergies");
        });

    $("#removeAlButton").on('click', function (e) {
        e.preventDefault();
    let selectedItems = $("#rightAllergies option:selected");
    selectedItems.detach().appendTo("#leftAllergies");
        });

    });
