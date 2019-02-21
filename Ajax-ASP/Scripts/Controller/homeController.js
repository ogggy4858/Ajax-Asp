var homeController = {
    init: function () {
        homeController.loadData();
      
    },
    registerEvent: function () {
      
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                alert(1);
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: 'Home/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html = html + Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class = \"label label-success\">Active</span>"  : "<span class = \"label label-danger\">Locked</span>"
                        });
                    });
                    $('#tblData').html(html);
                    homeController.registerEvent();
                }
            }
        });
    }
};
homeController.init();