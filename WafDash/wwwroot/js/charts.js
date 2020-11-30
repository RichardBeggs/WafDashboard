$(function () {
    GetPieChart();
    GetTimeChart();
});

function GetTimeChart() {
    $.ajax({
        url: "api/data/Get-by-time",
        success: function (result) {
            var d = new Array();
            var l = new Array();

            for (var i = 0; i < result.length; i++) {
                var name = result[i].name;
                var count = result[i].count;
                l.push(name);
                d.push(count);
            }

            var ctx = document.getElementById('timeChart').getContext('2d');
            var myChart = new Chart(ctx,
                {
                    type: 'line',
                    data: {
                        labels: l,
                        datasets: [
                            {
                                label: 'Visits per hour',
                                data: d,
                                backgroundColor: 'rgba(255, 99, 132, 1)',
                                borderColor: 'rgba(255, 99, 132, 1)',
                                fill: false
                            }
                        ]
                    },
                    options: {
                        scales: {
                            yAxes: [
                                {
                                    ticks: {
                                        beginAtZero: true
                                    }
                                }
                            ]
                        }
                    }
                });
        }
    });
}

function GetPieChart() {
    $.ajax({
        url: "api/data/Get-by-device",
        success: function (result) {
            var d = new Array();
            var l = new Array();

            for (var i = 0; i < result.length; i++) {
                var name = result[i].name;
                var count = result[i].count;
                l.push(name);
                d.push(count);
            }

            var ctx = document.getElementById('browserChart').getContext('2d');
            var myChart = new Chart(ctx,
                {
                    type: 'doughnut',
                    data: {
                        labels: l,
                        datasets: [
                            {
                                data: d,
                                backgroundColor: [
                                    'rgba(207, 0, 15, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)',
                                    'rgba(220,119,109, 1)',
                                    'rgb(228, 71, 171, 1)',
                                    'rgba(110,209,10, 1)',
                                    'rgba(250,109,109, 1)',
                                ],
                                borderColor: [
                                    'rgba(255, 99, 132, 1)',
                                    'rgba(54, 162, 235, 1)',
                                    'rgba(255, 206, 86, 1)',
                                    'rgba(75, 192, 192, 1)',
                                    'rgba(153, 102, 255, 1)',
                                    'rgba(255, 159, 64, 1)'
                                ],
                                borderWidth: 1
                            }
                        ]
                    },
                    options: {
                        responsive: true,
                        legend: {
                            position: 'top',
                        },
                        title: {
                            display: false,
                            text: 'Top 5 browsers'
                        },
                        animation: {
                            animateScale: true,
                            animateRotate: true
                        }
                    }
                });
        }
    });
}