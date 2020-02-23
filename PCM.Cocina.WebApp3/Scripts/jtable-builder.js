
var loadJsonOnTarget = function (columnfields) {
    $(this).jtable({
        title: $(this).data('jtable-title'),
        actions: {
            listAction: $(this).data('jtable-load-action')
        },
        fields: 
            columnfields
    });
}


