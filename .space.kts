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