import Vue from 'vue'
import Router from 'vue-router'
import store from '../store'

// Containers
const DefaultContainer = () => import('@/containers/DefaultContainer')

// Views
const Dashboard = () => import('@/views/Dashboard')

// Views - Pages
const Page404 = () => import('@/views/pages/Page404')
const Page500 = () => import('@/views/pages/Page500')
const Login = () => import('@/views/pages/Login')
const Register = () => import('@/views/pages/Register')

// Send Email
const SendEmail = () => import('@/views/sendEmail/SendEmail')

//Student
const StudentInfo = () => import('@/views/student/StudentInfo')
const Profile = () => import('@/views/student/Profile')
const Grades = () => import('@/views/student/Grades')
const Taxes = () => import('@/views/student/Taxes')

//Others
const TeachersList = () => import('@/views/others/TeachersList')

// Predictions
const PredictScore = () => import('@/views/predictions/PredictScore')
const PredictGrade = () => import('@/views/predictions/PredictGrade')
const Statistics = () => import('@/views/predictions/Statistics')

Vue.use(Router)





let router = new Router({
  mode: 'hash', // https://router.vuejs.org/api/#mode
  linkActiveClass: 'open active',
  scrollBehavior: () => ({ y: 0 }),
  routes: [
    { path: '/login', component: Login, meta: { title: 'Login' } },
    {
      path: '/',
      name: 'Home',
      redirect: '/dashboard',
      component: DefaultContainer,
      meta: {
        requiresAuth: true
      },
      children: [
        {
          path: 'info',
          name: 'StudentInfo',
          component: StudentInfo,
          props: true
        },
        {
          path: 'profile',
          name: 'User Profile',
          component: Profile
        },
        {
          path: 'eSIMS',
          redirect: '/eSIMS/grades',
          name: 'eSIMS',
          component: {
            render(c) { return c('router-view') }
          },
          children: [
            {
              path: 'grades',
              name: 'Grades',
              component: Grades
            },
            {
              path: 'taxes',
              name: 'Taxes',
              component: Taxes
            }
          ]
        },
        {
          path: 'mathematics',
          redirect: '/mathematics/prediction',
          name: 'Mathematics',
          component: {
            render(c) { return c('router-view') }
          },
          children: [
            {
              path: 'prediction',
              name: 'Predict score',
              component: PredictScore
            },
            {
              path: 'statistics',
              name: 'Statistics',
              component: Statistics
            }
          ]
        },
        {
          path: 'more',
          redirect: '/more/teachers',
          name: 'More',
          component: {
            render(c) { return c('router-view') }
          },
          children: [
            {
              path: 'teachers',
              name: 'Teachers',
              component: TeachersList
            },
            {
              path: 'sendEmail',
              name: 'SendEmail',
              component: SendEmail
            }
          ]
        },
        {
          path: 'dashboard',
          name: 'Dashboard',
          component: Dashboard
        },
        
        {
          path: 'sendEmail',
          meta: { label: 'SendEmail' },
          component: {
            render(c) { return c('router-view') }
          },
          children: [
            {
              path: '',
              component: SendEmail,
            }
          ]
        },
      ]
    },
    { path: '/register', name: 'Register', component: Register },
    { path: '/*', component: Page404, name: '404', meta: { title: 'FiiApp - Error' } }
  ]

  //routes: [
  //  //{
  //  //  path: '/',
  //  //  redirect: '/pages/login',
  //  //  name: 'Login',
  //  //  component: {
  //  //    render(c) { return c('router-view') }
  //  //  },
  //  //  children: [ ]
  //  //},
  //  {
  //    //path: '/dashboard',
  //    path: '/',
  //    redirect: '/dashboard',
  //    name: 'Home',
  //    component: DefaultContainer,
  //    children: [
  //      {
  //        path: 'dashboard',
  //        name: 'Dashboard',
  //        component: Dashboard
  //      },
  //      {
  //        path: 'theme',
  //        redirect: '/theme/colors',
  //        name: 'Theme',
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: 'colors',
  //            name: 'Colors',
  //            component: Colors
  //          },
  //          {
  //            path: 'typography',
  //            name: 'Typography',
  //            component: Typography
  //          }
  //        ]
  //      },
  //      {
  //        path: 'charts',
  //        name: 'Charts',
  //        component: Charts
  //      },
  //      {
  //        path: 'widgets',
  //        name: 'Widgets',
  //        component: Widgets
  //      },
  //      {
  //        path: 'users',
  //        meta: { label: 'Users'},
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: '',
  //            component: Users,
  //          },
  //          {
  //            path: ':id',
  //            meta: { label: 'User Details'},
  //            name: 'User',
  //            component: User,
  //          },
  //        ]
  //      },
  //      {
  //        path: 'sendEmail',
  //        meta: { label: 'SendEmail' },
  //        component: {
  //          render(c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: '',
  //            component: SendEmail,
  //          }
  //        ]
  //      },
  //      {
  //        path: 'base',
  //        redirect: '/base/cards',
  //        name: 'Base',
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: 'cards',
  //            name: 'Cards',
  //            component: Cards
  //          },
  //          {
  //            path: 'forms',
  //            name: 'Forms',
  //            component: Forms
  //          },
  //          {
  //            path: 'switches',
  //            name: 'Switches',
  //            component: Switches
  //          },
  //          {
  //            path: 'tables',
  //            name: 'Tables',
  //            component: Tables
  //          },
  //          {
  //            path: 'tabs',
  //            name: 'Tabs',
  //            component: Tabs
  //          },
  //          {
  //            path: 'breadcrumbs',
  //            name: 'Breadcrumbs',
  //            component: Breadcrumbs
  //          },
  //          {
  //            path: 'carousels',
  //            name: 'Carousels',
  //            component: Carousels
  //          },
  //          {
  //            path: 'collapses',
  //            name: 'Collapses',
  //            component: Collapses
  //          },
  //          {
  //            path: 'jumbotrons',
  //            name: 'Jumbotrons',
  //            component: Jumbotrons
  //          },
  //          {
  //            path: 'list-groups',
  //            name: 'List Groups',
  //            component: ListGroups
  //          },
  //          {
  //            path: 'navs',
  //            name: 'Navs',
  //            component: Navs
  //          },
  //          {
  //            path: 'navbars',
  //            name: 'Navbars',
  //            component: Navbars
  //          },
  //          {
  //            path: 'paginations',
  //            name: 'Paginations',
  //            component: Paginations
  //          },
  //          {
  //            path: 'popovers',
  //            name: 'Popovers',
  //            component: Popovers
  //          },
  //          {
  //            path: 'progress-bars',
  //            name: 'Progress Bars',
  //            component: ProgressBars
  //          },
  //          {
  //            path: 'tooltips',
  //            name: 'Tooltips',
  //            component: Tooltips
  //          }
  //        ]
  //      },
  //      {
  //        path: 'buttons',
  //        redirect: '/buttons/standard-buttons',
  //        name: 'Buttons',
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: 'standard-buttons',
  //            name: 'Standard Buttons',
  //            component: StandardButtons
  //          },
  //          {
  //            path: 'button-groups',
  //            name: 'Button Groups',
  //            component: ButtonGroups
  //          },
  //          {
  //            path: 'dropdowns',
  //            name: 'Dropdowns',
  //            component: Dropdowns
  //          },
  //          {
  //            path: 'brand-buttons',
  //            name: 'Brand Buttons',
  //            component: BrandButtons
  //          }
  //        ]
  //      },
  //      {
  //        path: 'icons',
  //        redirect: '/icons/font-awesome',
  //        name: 'Icons',
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: 'coreui-icons',
  //            name: 'CoreUI Icons',
  //            component: CoreUIIcons
  //          },
  //          {
  //            path: 'flags',
  //            name: 'Flags',
  //            component: Flags
  //          },
  //          {
  //            path: 'font-awesome',
  //            name: 'Font Awesome',
  //            component: FontAwesome
  //          },
  //          {
  //            path: 'simple-line-icons',
  //            name: 'Simple Line Icons',
  //            component: SimpleLineIcons
  //          }
  //        ]
  //      },
  //      {
  //        path: 'notifications',
  //        redirect: '/notifications/alerts',
  //        name: 'Notifications',
  //        component: {
  //          render (c) { return c('router-view') }
  //        },
  //        children: [
  //          {
  //            path: 'alerts',
  //            name: 'Alerts',
  //            component: Alerts
  //          },
  //          {
  //            path: 'badges',
  //            name: 'Badges',
  //            component: Badges
  //          },
  //          {
  //            path: 'modals',
  //            name: 'Modals',
  //            component: Modals
  //          }
  //        ]
  //      }
  //    ]
  //  },
  //  {
  //    path: '/pages',
  //    redirect: '/pages/404',
  //    name: 'Pages',
  //    component: {
  //      render (c) { return c('router-view') }
  //    },
  //    children: [
  //      {
  //        path: '404',
  //        name: 'Page404',
  //        component: Page404
  //      },
  //      {
  //        path: '500',
  //        name: 'Page500',
  //        component: Page500
  //      },
  //      {
  //        path: 'login',
  //        name: 'Login',
  //        component: Login
  //      },
  //      {
  //        path: 'register',
  //        name: 'Register',
  //        component: Register
  //      }
  //    ]
  //  }
  //]
})


router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (store.getters.isLoggedIn) {
      next()
      return
    }
    next('/login')
  } else {
    next()
  }
})

export default router
