job("Build and push Docker") {
    startOn {
    	gitPush { 
        	branchFilter {
            	"release/**"
            }
        }
    }
    
    docker {
        build {
            context = "docker"
            file = "./dockerfile"
            labels["vendor"] = "pinguin"
        }

        push("pinguin.registry.jetbrains.space/p/mp/mydocker/myimage") {
            tags("version")
        }
    }
}

container("openjdk:11") {
    kotlinScript { api ->
        api.space().projects.automation.deployments.start(
            project = api.projectIdentifier(),
            targetIdentifier = TargetIdentifier.Key("staging"),
            version = "1.0.0",
            // automatically update deployment status based on a status of a job
            syncWithAutomationJob = true
        )
    }
}