var home = {
    init: function () {
        home.loadData();

    },
    registerEvent: function () {
        $('.txtSalary').off('keypress').on('keypress', function (e) {
            if (e.which == 13) {
                var id = $(this).data('id');
                var value = $(this).val();
                home.updataSalary(id, value);
            }
        });
    },
    updataSalary: function (id, value) {
        var aaa = {
            ID: id,
            Salary: value
        };
        $.ajax({
            url: '/Home/Update',
            type: 'POST',
            dataType: 'json',
            data: { model: JSON.stringify(aaa) },
            success: function(response) {
                if (response.status) {
                    alert('update success.');
                }
                else {
                    alert('update false.');
                }
            }
        });
    },

    loadData: function () {
        $.ajax({
            url: 'Home/LoadData',
            type: 'GET',
            dataType: 'json',
            success: function (respone) {
                if (respone.status) {
                    var data = respone.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ID: item.ID,
                            Name: item.Name,
                            Salary: item.Salary,
                            Status: item.Status == true ? "<span class = \"label label-success\">Active</span>" : "<span class = \"label label-danger\">Locked</span>"
                        });
                    });
                    $('#tblData').html(html);
                    home.registerEvent();
                }
                else {
                    alert('False');
                }
            }
        })

    }
};

home.init();

