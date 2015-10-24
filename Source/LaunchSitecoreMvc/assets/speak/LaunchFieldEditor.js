define(["sitecore",
  "/-/speak/v1/ExperienceEditor/ExperienceEditor.js",
  "/-/speak/v1/ExperienceEditor/ExperienceEditor.Context.js"],
  function (Sitecore, ExperienceEditor, ExperienceEditorContext) {
      Sitecore.Commands.LaunchFieldEditor =
      {
          canExecute: function (context) {
              if (ExperienceEditor.isInMode("edit")) {
                  return true;
              }
              return false;
          },
          execute: function (context) {
              context.currentContext.argument = context.button.viewModel.$el[0].accessKey;

              ExperienceEditor.PipelinesUtil.generateRequestProcessor("ExperienceEditor.GenerateFieldEditorUrl", function (response) {
                  var DialogUrl = response.responseValue.value;
                  var dialogFeatures = "dialogHeight: 680px;dialogWidth: 520px;";
                  ExperienceEditor.Dialogs.showModalDialog(DialogUrl, '', dialogFeatures, null);
              }).execute(context);
          }
      };
  });