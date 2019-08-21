# Sonarqube Configuration-as-code
## Goal
This projects aims to assist the configuration of sonar though code.

The goal is to execute a command like

```bash
sonarqube-casc -f sonarqube_conf.yaml -h http://sonarqube_host -t access_token
```

and sonarqube instance at `http://sonarqube_host` will be correctly configured according to the specification described in the `sonarqube_conf.yaml` with a content similar to:

```yaml
admin:
    system:
        loglevel: TRACE|DEBUG|INFO
    settings:
    plugins:
        - key1: version
        - key2: version
        - key3: version
    acl:
        groups:
            - name: group1
              description: group description
              permissions:
                - admin
                - profileadmin
                - gateadmin
                - scan
                - provisioning
            - name: group2
              description: group description
        users:
            - login: login1
              name: user1
              password: password1
              email: email1
            - login: login2
              name: user2
              password: password2
              email: email2
        template:
            - name: template
              description: description
              pattern: pattern
              permissions:
                    - type: group
                      groupId: groupId
                      groupName: groupname|anyone
                      permissions: 
                        - admin
                        - codeviewer
                        - issueadmin
                        - securityhotspotadmin
                        - scan
                        - user
                    - type: user
                      login: login1
                      permissions: 
                        - admin
                        - codeviewer
                        - issueadmin
                        - securityhotspotadmin
                        - scan
                        - user
quality_profile:
    - name: qp1
      language: js
      rules:
        - rule: csharpsquid:S3431
          params: params=key1=v1;key2=v2
          severity: INFO | MINOR | MAJOR | CRITICAL | BLOCKER
quality_gate:
    - name: qg1
      default: true
      organization: org1
      conditions:
        - metric: metricname ??
          error: 10
          op: GT
projects:
    - key: project_key
      name: project_name
      visibility: private|public
      long_lived_branches: (branch|release)-.*
      settings:
        - key1: value1
        - key2: value2
        - key3: 
            - value1
            - value2
      quality_profiles:
        - profile1
        - profile2
      quality_gate: qg1
      tags:
        - app_app1
        - app_app2
      links:
        - name: url
        - name: url
      permissions:
        - type: group
          groupId: groupId
          groupName: groupname|anyone
          permissions: 
            - permissions
            - admin
            - codeviewer
            - issueadmin
            - securityhotspotadmin
            - scan
            - user
        - type: user
          login: login1
          permissions: 
            - permissions
            - admin
            - codeviewer
            - issueadmin
            - securityhotspotadmin
            - scan
            - user
      webhook:
        - name: name
          url: url
          secret: secret
```

