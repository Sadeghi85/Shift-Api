// Powered by Infostretch 

timestamps {

node () {

	stage ('shift-build - Checkout') {
 	 checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: '959aba60-5944-44a9-8858-6608490401ca', url: 'http://192.168.1.30:3000/ysp/shift-api']]]) 
	}
	stage ('shift-build - Build') {
 	
// Unable to convert a build step referring to "hudson.plugins.timestamper.TimestamperBuildWrapper". Please verify and convert manually if required.
// Unable to convert a build step referring to "io.jenkins.plugins.dotnet.DotNetWrapper". Please verify and convert manually if required.
// Unable to convert a build step referring to "io.jenkins.plugins.dotnet.commands.msbuild.Build". Please verify and convert manually if required.
// Unable to convert a build step referring to "io.jenkins.plugins.dotnet.commands.msbuild.Publish". Please verify and convert manually if required.
		archiveArtifacts allowEmptyArchive: false, artifacts: 'src/Shift.Api/bin/Release/net6.0/publish/**', caseSensitive: false, defaultExcludes: true, fingerprint: true, onlyIfSuccessful: true 
	}
}
}