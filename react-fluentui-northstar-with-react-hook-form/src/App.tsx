//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

import React from 'react';
import './App.css';
import {
  Card,
  Form,
  FormButton,
  FormDatepicker,
  FormInput,
  FormMessage,
  FormTextArea,
  Provider,
  teamsTheme
} from '@fluentui/react-northstar';
import {
  Controller,
  FieldErrors,
  useForm
} from 'react-hook-form';

interface IDiaryForm {
  date?: Date,
  title?: string,
  content?: string,
}

function App() {
  const form = useForm<IDiaryForm>();
  const [json, setJson] = React.useState<string>("");

  const handleSubmitValid = React.useMemo(() => (value: IDiaryForm) => {
    setJson(JSON.stringify(value));
  }, []);

  const handleSubmitError = React.useMemo(() => (error: FieldErrors) => {
    console.error(error);
  }, []);

  return (
    <Provider theme={teamsTheme}>
      <div className="app">
        <Form onSubmit={form.handleSubmit(handleSubmitValid, handleSubmitError)}>
          <Controller
            control={form.control}
            defaultValue={new Date()}
            name="date"
            rules={{
              required: true,
            }}
            render={({ field, fieldState }) => (
              <FormDatepicker
                ref={field.ref}
                errorMessage={fieldState.error?.message}
                label="Date"
                selectedDate={field.value}
                onDateChangeError={(_, value) => form.setError(field.name, { message: value?.error })}
                onDateChange={(_, props) => field.onChange(props?.value)}
                onBlur={field.onBlur}
              />
            )}
          />
          <Controller
            control={form.control}
            defaultValue={""}
            name="title"
            rules={{
              required: 'The value is requred',
            }}
            render={({ field, fieldState }) => (
              <FormInput
                ref={field.ref}
                errorMessage={fieldState.error?.message}
                fluid
                label="Title"
                placeholder="(Title)"
                value={field.value}
                onChange={(_, props) => field.onChange(props?.value)}
                onBlur={field.onBlur}
              />
            )}
          />
          <Controller
            control={form.control}
            defaultValue={""}
            name="content"
            rules={{
              required: 'The value is requred',
            }}
            render={({ field, fieldState }) => (
              <FormTextArea
                ref={field.ref}
                errorMessage={fieldState.error?.message}
                fluid
                label="Content"
                placeholder="(Content)"
                value={field.value}
                onChange={(_, props) => field.onChange(props?.value)}
                onBlur={field.onBlur}
              />
            )}
          />
          <FormButton content="Submit" />
        </Form>
        {json && (<Card fluid>{json}</Card>)}
      </div>
    </Provider>
  )
}

export default App
