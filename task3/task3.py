def getKey(obj: myobject):
    keys = list(obj)
    if len(keys) != 1:
        raise Exception('multiple keys or blank object details')
    else:
        return keys[0]


def getNestedValue(obj: myobject, key: str, isFound = False):
    # print(obj, key, isFound)
    if type(obj) is not myobject and not isFound:
        return None
    if (isFound or (key in obj.keys())) :
        if type(obj[key]) is myobject:
            return getNestedValue(obj[key], getKey(obj[key]), True)
        else:
            # print(f'obj[getKey(obj)]: {obj[getKey(obj)]}')
            return obj[getKey(obj)]
    else:
        nestedKey = getKey(obj)
        return getNestedValue(obj[nestedKey], key, False)

if __name__ == '__main__':
    obj = {'a': {'b': {'c': 'd'}}}
    value = getNestedValue(obj, 'c')
    print(value)
