
$(document).ready(function () {
    //Client Clock
    $('#Clock').jclock();

    //Accrodion 
    $("#Accordion").accordion({
        header: "h3",
        autoHeight: false,
        navigation: true
    });

    $(".liAccordion").click(function (event) {
        window.location.hash = this.hash;
    });    
        
});