// pipeline {
//     agent any

//     environment {
//         DOTNET_CLI_HOME = "${env.WORKSPACE}"  // Fix for missing HOME variable
//     }
 
//     stages {
//         stage('Checkout') {
//             steps {
//                 git url: 'https://github.com/DivyanshuDilip/BDDFrameworkRepo.git', branch: 'BDDFrameworkProject'
//             }
//         }
 
//         stage('Restore') {
//             steps {
//                 dir('MyNUnitProject') {
//                     sh 'dotnet restore'
//                 }
//             }
//         }
 
//         stage('Build') {
//             steps {
//                 dir('MyNUnitProject') {
//                     sh 'dotnet build --configuration Release'
//                 }
//             }
//         }
 
//         stage('Test') {
//             steps {
//                 dir('MyNUnitProject') {
//                     sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
//                 }
//             }
//         }
 
//         stage('Publish Test Results') {
//             steps {
//                 echo 'Note: TRX format not supported by junit step. Convert to XML if needed.'
//             }
//         }
//     }
// }

pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = "${env.WORKSPACE}"  // Fix for missing HOME variable
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/DivyanshuDilip/DotNetCsvFileProject.git', branch: 'CsvFileProject'
            }
        }

        stage('Restore') {
            steps {
                dir('DataDrivenTests') {
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('DataDrivenTests') {
                    sh 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('DataDrivenTests') {
                    sh 'dotnet test --logger "trx;LogFileName=test_results.trx"'
                }
            }
        }

        stage('Publish Test Results') {
            steps {
                echo 'Note: TRX format is not directly supported by the junit plugin. You may need to convert to JUnit XML if publishing results to Jenkins.'
            }
        }
    }
}
