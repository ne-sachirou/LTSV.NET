desc 'Pack a project for NuGet.'
task :pack_nuget do
  Dir.chdir 'LTSV'
  sh 'nuget pack'
end

task :default => [:pack_nuget]
