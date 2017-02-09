$(document).ready(function () {
    var OriginalOptions;

    loadDatePicker();

    //AutoPupolate();
    //when the user changes off of the zip field:
    $(document).eq(0).on("change", "input[id*='ZipCode']", function (e) {
        e.preventDefault();
        AutoPupolate();
    });

   
});
function loadDatePicker() {
   // alert('Datepicker Loaded');
    $(("input[id*='Date']")).datepicker({
        format: 'dd M yyyy',
        autoclose: 'true',
        todayHighlight: 'true',
        maxViewMode: 'decade',
        orientation: "bottom auto"
    }).data('datepicker');
}
function AutoPupolate() {
    var zip = $("input[id*='ZipCode']").eq(0).val();
    //alert("AutoPupolate is working");
    var city = '';
    var stateView = '';
    var state = '', state_abbr = '';
    var county = '';
    var latitude, longtitude;
    //make a request to the google geocode api
    $.getJSON('https://maps.googleapis.com/maps/api/geocode/json?address=' + zip).success(function (response) {
        //find the city and state
        var components = response.results[0].address_components;
        $.each(components, function (index, component) {
            var types = component.types;
            $.each(types, function (index, type) {
                if (type == 'locality') {
                    city = component.long_name;
                }
                else if (type == 'administrative_area_level_1') {
                    stateView = component.short_name + " - " + component.long_name;
                    state = component.long_name;
                    state_abbr = component.short_name;
                }

                else if (type == "administrative_area_level_2") {
                    county = component.long_name;
                }

            });
        });
        //pre-fill the city and state

        //check for multiple cities
        var cities = response.results[0].postcode_localities;
        var $select = $("select[id*='City']").eq(0);
        //var OldSelect = $("select[id*='City']").eq(0).children('option:selected').val();
        var OldSelect = $("input:hidden[id*='City']").val();
        //alert(OldSelect);
        $select.empty();
        var $option;

        //alert(cities);


        if (cities) {
            //turn city into a dropdown if necessary


            $.each(cities, function (index, locality) {
                $option = $(document.createElement('option'));
                $option.html(locality);
                $option.attr('value', locality);
                if (locality == OldSelect) {
                    $option.attr('selected', 'selected');
                }

                $select.append($option);
            });

        } else {
            $option = $(document.createElement('option'));
            $option.html(city);
            $option.attr('value', city);
            $option.attr('selected', 'selected');
            $select.append($option);
        }





        $("input[id*='StateName']").eq(0).text(stateView);
        $("input[id*='StateName']").eq(0).val(state);
        $("input[id*='State']").eq(0).val(state_abbr);

        $("input[id*='County']").eq(0).val(county);


        var location = response.results[0].geometry.location;

        $("input[id*='Location_lat']").eq(0).val(location.lat);
        $("input[id*='Location_lng']").eq(0).val(location.lng);



    });

}
