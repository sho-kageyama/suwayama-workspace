function main(){
    var ctx = document.getElementById('chart').getContext('2d');
    Chart.defaults.global.defaultFontColor = '#353535';
    var myChart = new Chart(ctx, {
                            type: 'bar',
                            data: {
                            labels: ['1月', '２月', '３月', '４月', '５月','６月','７月','８月','９月','10月','11月','12月'],
                            datasets: [{
                                       label: '売上',
                                       data: [50000, 150000, 100000, 80000, 200000, 250000, 120000, 300000, 200000, 10000, 600000, 720000],
                                       backgroundColor: [
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         '#990000',
                                                         ],
                                       borderColor: [
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     '#990000',
                                                     ],
                                       borderWidth: 1
                                       },{
                                       label: '人件費',
                                       data: [5000, 15000, 10000, 8000, 20000, 25000, 5000, 10000, 30000, 12000, 40000, 60000],
                                       backgroundColor: [
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         '#cccccc',
                                                         ],
                                       borderColor: [
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     '#cccccc',
                                                     ],
                                       borderWidth: 1
                                       },{
                                       label: '入金',
                                       data: [0, 0, 100, 800, 2000, 20000, 30000, 50000, 10000, 5000, 45000, 50000],
                                       backgroundColor: [
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         ],
                                       borderColor: [
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                         '#bdb76b',
                                                     ],
                                       borderWidth: 1
                                       },{
                                       label: '経費',
                                       data: [2000, 0, 1500, 1000, 200, 5000, 5000, 5000, 5000, 5000, 5000, 5000],
                                       backgroundColor: [
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         ],
                                       borderColor: [
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                         '#4682b4',
                                                     ],
                                       borderWidth: 1
                                       },{
                                       label: '粗利(累計)',
                                       data: [43000, 134900, 87700, 70200, 177800, 240000, 140000, 335000, 175000, 0, 600000, 705000],
                                       backgroundColor: [
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         ],
                                       borderColor: [
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                         '#d70035',
                                                     ],
                                       borderWidth: 1
                                       }]
                            }, options : {
                            	legend : {
                            		labels :{
                            			fontColor: "#353535"
                            		}
                            	}
                            },
                            
                            });
}
main();
// window.addEventListener('load', function (e) {
//     main();
// })
