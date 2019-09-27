import { Component, OnInit, AfterViewInit, ChangeDetectionStrategy } from '@angular/core';
// import 'chart.js'
// import 'src/assets/js/bar.js'

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit, AfterViewInit {
  constructor() { }

  ngOnInit() {
    this.chartPrott();
  }

   ngAfterViewInit() {
    this.chartPrott()
  }

  chartPrott(){
    const bar = document.createElement('script')
    const div = document.getElementById('base')

    bar.async = true;
    bar.setAttribute('src','../../assets/js/bar.js')

    div.parentNode.insertBefore(bar,div.nextSibling);

  }

}
