$(document).ready(function () {
    loadDatePicker();
    $.validator.unobtrusive.parse($('input'));
    //Show Player's Details Including personal Information and Player Information
    var profile = $("div#Profile").show();


    var playerInfo = $("div#PlayerInformation").hide();


    //Original Labels
    var originalLabels = [];

    //Replacement Labels
    var replacementLabels = [];


    //Origininal entries
    var originalEntries = [];


    //Original Selects options

    var SelectsOptions = [];


    $("li").click(function (index) {
        var Selected = $(this);
        Selected.addClass("active");
        Selected.siblings().removeClass("active");


        if (Selected.find("a").text() == "Profile") {
            playerInfo.hide();
            profile.fadeIn();

        } else {
            profile.hide();
            playerInfo.fadeIn();

        }
    });

    var form;
    var button_group = $("div.ForProfile").find("div.pull-right");
    var details_section;
    var edit_button;
    var cancelSaveButton;
    var saveButton;
    // edit_button STARTS//

    $(document).on("click", ".edit_button", function () {
        AutoPupolate();

        edit_button = $(this);
        cancelSaveButton = $(this).siblings('.cancelSave_button');
        saveButton = $(this).siblings('.save_button');


        edit_button.css("display", "none");
        cancelSaveButton.css("display", "inline");
        saveButton.css("display", "inline");
        ////DatePicker for Birth date
        //var BirthDate = $("#personalInformation_BirthDate").datepicker({
        //    format: 'dd M yyyy',
        //    autoclose: 'true',
        //    todayHighlight: 'true',
        //    maxViewMode: 'decade',
        //    orientation: "bottom auto"
        //}).data('datepicker');
        originalLabels = [];
        originalEntries = [];



        details_section = $(this).parent().parent().find("dl.dl-horizontal");
        replacementLabels = details_section.find("input#replacementLabels").val().split(',');

        details_section.children("dt").each(function (index) {

            //Replace original labels
            originalLabels.push($(this).text());
            $(this).text(replacementLabels[index]);


        });


        details_section.find("input#originalLabels").val(originalLabels);

        details_section.find("div.entry").css("display", "none");

        //alert(JSON.stringify(originalEntries));
        details_section.find("div.edit_field").css("display", "block");

        form = $(this).closest("form");
      
        form[0].reset();
        var OtherForms
        //var keyword = $('input#PeopertySelector').val();

    });
    // edit_button ENDS//

    // cancelSaveButton STARTS//
 
    $(document).on("click", ".cancelSave_button", function () {
        edit_button = $(this).siblings('.edit_button');
        cancelSaveButton = $(this);
        saveButton = $(this).siblings('.save_button');

        edit_button.css("display", "inline");
        cancelSaveButton.css("display", "none");
        saveButton.css("display", "none");

        details_section = $(this).parent().parent().find("dl.dl-horizontal");

        originalLabels = details_section.find("input#originalLabels").val().split(',');
        details_section.find("input#originalLabels").val('');

        details_section.children("dt").each(function (index) {
            $(this).text(originalLabels[index]);

        });


        details_section.find("div.entry").css("display", "block");
        details_section.find("div.edit_field").css("display", "none");
        $('.field-validation-error').empty();
        form[0].reset();

    });

    // cancelSaveButton ENDS//

    // saveButton STARTS//
    
    $(document).on("click", ".save_button", function (e) {
        edit_button = $(this).siblings('.edit_button');
        cancelSaveButton = $(this).siblings('.cancelSave_button');
        saveButton = $(this);

      e.preventDefault();


        //Update values by ajax request
     
        var keyword = $('input#PeopertySelector').val();
        var formValues = form.serializeArray();
      
        var DATA = {};
        DATA = formValues;
      
       // alert(JSON.stringify(DATA));
        var playerId = $(this).attr('id');
        
        details_section = saveButton.parent().siblings("dl.dl-horizontal");

        $.ajax({
            url: "/Players/Update/" + playerId,
            method: "PUT",
            data: DATA,
            success: function (data) {
                
                form.html(data);
                loadDatePicker();
            },
            error: function () {
              
                form.valid();
            }
        });

    });
});