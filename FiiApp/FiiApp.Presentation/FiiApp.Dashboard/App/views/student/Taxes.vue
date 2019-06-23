<template>
  <div class="animated fadeIn">
    <b-card class="boxModel-zero sortable" header-bg-variant="primary" header="Student's payment obligations">
      <b-table class="table table-borderless table-primary" hover striped outlined small responsive="sm" :items="studentTaxesData" :fields="studentTaxesFields" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
    <b-card class="boxModel-zero sortable" header-bg-variant="primary" header="Student's payment documents">
      <b-table class="table table-borderless table-primary" hover striped outlined small responsive="sm" :items="studentPaymentDocsData" :fields="studentPaymentDocsFields" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
    <b-card class="boxModel-zero" header-bg-variant="primary" header="Payment history">
      <b-table class="table table-borderless table-primary" striped outlined small responsive="sm" :items="studentPaymentHistoryData" :fields="studentPaymentHistoryFields" show-empty empty-text="There are no data to show">
      </b-table>
    </b-card>
  </div>
</template>

<script>
  import axios from 'axios'

export default {
  name: 'c-table',
  inheritAttrs: false,
  props: {
  },
  data: () => {
    return {
      studentPaymentHistoryFields: [
        { key: 'name', label: 'Name', class: 'text-center' },
        { key: 'dueAmount', label: 'Due Amount', class: 'text-center' },
        { key: 'destination', label: 'Destination', class: 'text-center' },
        { key: 'paidAmount', label: 'Paid Amount', class: 'text-center' },
        { key: 'date', label: 'Date', class: 'text-center' }, 
      ],

      studentPaymentHistoryData: [
        { name: "Payment document [EN15 032530]", dueAmount: "300", destination: "RON Account", paidAmount: "300", date: "29.10.2015" },
        { name: "Receipt [EN15 032530]", dueAmount: "300", destination: "Registration fee for bachelor admission", paidAmount: "300", date: "29.10.2015" },
        { name: "Payment document [24]", dueAmount: "50", destination: "RON Account", paidAmount: "50", date: "4.11.2015" },
        { name: "Receipt [24]", dueAmount: "50", destination: "Bachelor registration fee", paidAmount: "50", date: "4.11.2015" },
        { name: "Payment document [1804021433370020]", dueAmount: "350", destination: "RON Account", paidAmount: "350", date: "5.04.2018" },
        { name: "Receipt [1804021433370020]", dueAmount: "350", destination: "Resettlement fee for didactic activity(semester 4)", paidAmount: "350", date: "5.04.2018" },
      ],

      studentPaymentDocsFields: [
        { key: 'name', label: 'Name', class: 'text-center' },
        { key: 'paymentDocNumber', label: 'Payment Document Number', class: 'text-center' },
        { key: 'docDate', label: 'Document Date', class: 'text-center' },
        { key: 'amount', label: 'Amount', class: 'text-center' }
      ],

      studentPaymentDocsData: [
        { name: "Receipt", paymentDocNumber: "EN15 032530", docDate: "14.07.2015", amount: "300" },
        { name: "Receipt", paymentDocNumber: "24", docDate: "24.07.2015", amount: "50" },
        { name: "Receipt", paymentDocNumber: "1804021433370020", docDate: "2.04.2018", amount: "350" },
      ],

      studentTaxesFields: [
        { key: 'name', label: 'Name', class: 'text-center' },
        { key: 'amount', label: 'Amount', class: 'text-center' },
        { key: 'currency', label: 'Currency', class: 'text-center' },
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'academicYear', label: 'academicYear', class: 'text-center' },
        { key: 'paidAmount', label: 'Pain amount', class: 'text-center' },
      ],

      studentTaxesData: [
        { name: "Bachelor", amount: "300", currency: "RON", semester: "0", academicYear: "2015", paidAmount: "300" },
        { name: "Bachelor", amount: "50", currency: "RON", semester: "1", academicYear: "2015", paidAmount: "50" },
      ],

      gradesFields: [
        { key: 'evaluationName', label: 'Name', class: 'text-center', sortable: true },
        { key: 'evaluationType', label: 'Type', class: 'text-center', sortable: true },
        { key: 'teacherName', label: 'Teacher Name', class: 'text-center', sortable: true },
        { key: 'maxScore', label: 'Max Score', class: 'text-center', sortable: true },
        { key: 'yourScore', label: 'Your Score', class: 'text-center', sortable: true },
        { key: 'grade', label: 'Your Grade', class: 'text-center', sortable: true },
        { key: 'evalDate', label: 'Date', class: 'text-center', sortable: true },
      ],

      meansFields: [
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'average', label: 'Average', class: 'text-center' },
        { key: 'ectsMean', label: 'ECTS Mean', class: 'text-center' },
        { key: 'points', label: 'Points', class: 'text-center' },
        { key: 'credits', label: 'Credits', class: 'text-center' },
        { key: 'averageYear', label: 'Average Per Year', class: 'text-center' },
        { key: 'ectsMeanYear', label: 'ECTS Mean Per Year', class: 'text-center' },
        { key: 'pointsYear', label: 'Points Per Year', class: 'text-center' },
        { key: 'creditsYear', label: 'Credits Per Year', class: 'text-center' },
      ],

      finalGradesFields: [
        { key: 'academicYear', label: 'Academic Year', class: 'text-center' },
        { key: 'semester', label: 'Semester', class: 'text-center' },
        { key: 'courseName', label: 'Course Name', class: 'text-center', sortable: true },
        { key: 'grade', label: 'Final Grade', class: 'text-center', sortable: true },
        { key: 'credits', label: 'Credits', class: 'text-center', sortable: true },
        { key: 'date', label: 'Date', class: 'text-center', sortable: true },
      ],

      finalGradesData: [],
      gradesData: [],
      trajectoryData: [],
      meansData: [],
      studentInfo: {},
      currentCourseClicked: 'Course'
    }
  },
    methods: {
    }
}
</script>

<style>
  .boxModel-zero .card-body {
    padding: 0;
  }

  .boxModel-zero .card-header {
    border: 0;
  }

  .boxModel-zero .card-body .table {
    margin: 0;
  }

  .table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
    background-color: skyblue;
  }

  .sortable tr {
    cursor: pointer;
  }
</style>

