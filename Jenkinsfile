pipeline {
    agent any

   

    stages {
        stage('Build') {
            steps {
                script {
                    // Build Docker image
                    sh 'docker build --no-cache -t basketms/api -f DevOps-BasketMicroserviceCleanArchitecture/Dockerfile .'
                }
            }
        }

        stage('Push and Deploy') {
            steps {
                script {
                    // Stop and remove existing container (if any)
                    sh 'docker stop basketms || true && docker rm basketms || true'

                    // Run a new container with the built image
                    sh 'docker run -d --name basketms -p 5004:80 --env "ASPNETCORE_ENVIRONMENT=Development" basketms/api:latest'
                }
            }
        }
    }
}
